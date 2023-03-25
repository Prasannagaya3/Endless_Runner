using UnityEngine;

public class CharacterInvert : MonoBehaviour
{
    // string input = new string["C", "H", "A", "R"];
    string[] input = new string[] {"C", "H", "A", "R" };
    string output = "";
    int length;

    private void Start()
    {
        length = input.Length - 1;

        while (length >= 0)
        {
            output = output + input[length];
            length--;
        }
        Debug.Log($"reverse: {output}");
    }
}
