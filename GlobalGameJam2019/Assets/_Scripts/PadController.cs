using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadController : APlayerController
{
    protected override void CollectInputs()
    {
        horizontal = Input.GetAxis("HorizontalPad");
        vertical = Input.GetAxis("VerticalPad");

        horizontalSecondary = Input.GetAxis("HorizontalPad2");
        verticalSecondary = Input.GetAxis("VerticalPad2");

        shooting = Input.GetButton("Fire1Pad");
    }
}
