using System;
using UnityEngine;
using InfinityHeroes.News.Framework;
using InfinityHeroes.News;

public class ArticleDownloadManager : MonoBehaviour
{
    [SerializeField] private int numArticles = 3;
    [SerializeField] private Article[] articles;

    public void DownloadArticles()
    {
        NewsClient newsClient = new NewsClient();

        StartCoroutine(newsClient.GetArticles(response => 
                                            {
                                                for (int i = 0; i < numArticles; i++)
                                                {
                                                    try
                                                    {
                                                        // send article data to corresponding article object
                                                        string imageURl = response.NewsItems[i].ImageURL;
                                                        string contents = response.NewsItems[i].Contents;
                                                        Action linkOpenAction = response.NewsItems[i].ArticleSource.Open;

                                                        articles[i].gameObject.SetActive(true);
                                                        articles[i].SetImage(imageURl);
                                                        articles[i].SetContent(contents);
                                                        articles[i].SetLinkOpenAction(linkOpenAction);
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        Debug.LogException(ex);
                                                    }
                                                }
                                            }
                                            ));
    }
}