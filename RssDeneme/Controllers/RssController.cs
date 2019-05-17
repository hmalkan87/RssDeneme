using RssDeneme.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace RssDeneme.Controllers
{
    public class RssController : Controller
    {
        // GET: Rss
        public ActionResult Index()
        {
            //web request ile xml metnini alıyoruz
            WebRequest request = WebRequest.Create("https://www.cnnturk.com/feed/rss/bilim-teknoloji/news");
            WebResponse response = request.GetResponse();

            //gelen xml metnini XmlDocument tipine çeviriyoruz
            Stream rssStream = response.GetResponseStream();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(rssStream);

            //haberlerin olduğu listeyi alıyoruz
            XmlNodeList xmlNodeList = xmlDocument.SelectSingleNode("rss").SelectSingleNode("channel").SelectNodes("item");

            //haber XML listesinde dönerek kendi modelimizi dolduruyoruz
            List<RssHaberModel> viewModel = new List<RssHaberModel>();

            for (int i = 0; i < xmlNodeList.Count; i++)
            {
                RssHaberModel haber = new RssHaberModel();

                haber.Description = xmlNodeList.Item(i).SelectSingleNode("description").InnerText;
                haber.Title = xmlNodeList.Item(i).SelectSingleNode("title").InnerText;
                haber.ImageUrl = xmlNodeList.Item(i).SelectSingleNode("image").InnerText;
                haber.pubDate = xmlNodeList.Item(i).SelectSingleNode("pubDate").InnerText;
                haber.Link = xmlNodeList.Item(i).SelectSingleNode("link").InnerText;

                viewModel.Add(haber);
            }

            return View(viewModel);
        }
    }
}