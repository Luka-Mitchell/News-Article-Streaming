using System;
using UnityEngine;
using UnityEngine.UI;
using InfinityHeroes.News;

public class Article : MonoBehaviour
{
    [SerializeField] private RawImage articleImage;
    [SerializeField] private TMPro.TextMeshProUGUI articleContents;
    private Action linkOpenAction;

    // sets the image texture to the texture from the given image URL
    public void SetImage(string imageURL)
    {
        StartCoroutine(TextureStreamer.ReadFromURL(imageURL, texture => articleImage.texture = texture));
    }

    public void SetContent(string content) { articleContents.text = content; }

    public void SetLinkOpenAction(Action action) { linkOpenAction = action; }

    public void OpenLink()
    {
        linkOpenAction();
    }
}