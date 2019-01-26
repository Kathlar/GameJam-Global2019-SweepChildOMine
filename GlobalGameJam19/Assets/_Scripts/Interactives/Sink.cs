using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : ItemChanger
{
    public ParticleSystem waterParticle;
    protected AudioSource waterSound;

    protected override void Start()
    {
        waterSound = GetComponent<AudioSource>();
        base.Start();
        waterParticle.Stop(true);
    }

    private void Update()
    {
        base.Update();
        if(itemOn != null)
        {
            itemOn.status += Time.deltaTime * itemChangeSpeed;
            progressBar.SetValue(itemOn.status);
            if (itemOn.status >= 1) Finnish();
        }
    }

    protected override void PutOn(ItemObject item, Transform placePosition = null)
    {
        if(item.objectType == ItemObjectType.Plate)
        {
            waterSound.Play();
            progressBar.Show();
            base.PutOn(item);
            waterParticle.Play(true);
        }
    }

    public override void PutOff()
    {
        base.PutOff();
        progressBar.Hide();
        waterParticle.Stop(true);
        waterSound.Stop();
    }

    protected override void Finnish()
    {
        if (itemOn.objectType == ItemObjectType.Plate && itemOn.dirt != null) Destroy(itemOn.dirt);
        base.Finnish();
    }
}
