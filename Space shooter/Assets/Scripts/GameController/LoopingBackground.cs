using UnityEngine;

public class LoopingBackground : MonoBehaviour
{
    public float speed = 1f; // Tốc độ di chuyển của background

    private Transform[] backgrounds; // Mảng chứa các Transform của hình ảnh nền
    private float backgroundHeight; // Chiều cao của hình ảnh nền

    private void Start()
    {
        // Lấy các Transform của hình ảnh nền
        backgrounds = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            backgrounds[i] = transform.GetChild(i);
        }

        // Lấy chiều cao của hình ảnh nền
        backgroundHeight = backgrounds[0].GetComponent<SpriteRenderer>().bounds.size.y;
    }

    private void Update()
    {
        // Di chuyển các hình ảnh nền
        for (int i = 0; i < backgrounds.Length; i++)
        {
            // Di chuyển hình ảnh nền theo trục y với tốc độ được đặt
            backgrounds[i].position += Vector3.down * speed * Time.deltaTime;

            // Nếu hình ảnh nền di chuyển hết khỏi màn hình, di chuyển nó lên trên để tạo hiệu ứng looping
            if (backgrounds[i].position.y < -backgroundHeight)
            {
                backgrounds[i].position += Vector3.up * backgroundHeight * 2;
            }
        }
    }
}
