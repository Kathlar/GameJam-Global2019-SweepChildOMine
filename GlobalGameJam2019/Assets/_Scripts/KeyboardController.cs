using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : APlayerController
{
    protected override void CollectInputs()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        horizontalSecondary = Input.GetAxis("Mouse X");
        verticalSecondary = Input.GetAxis("Mouse Y");

        shooting = Input.GetMouseButton(0);
    }
}
