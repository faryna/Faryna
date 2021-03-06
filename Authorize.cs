﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VK_API
{
    public enum AppID { id = 3877665 }
    public enum VkontakteScopeList
    {
        /// <summary>
        /// Пользователь разрешил отправлять ему уведомления. 
        /// </summary>
        notify = 1,
        /// <summary>
        /// Доступ к друзьям.
        /// </summary>
        friends = 2,
        /// <summary>
        /// Доступ к фотографиям. 
        /// </summary>
        photos = 4,
        /// <summary>
        /// Доступ к аудиозаписям. 
        /// </summary>
        audio = 8,
        /// <summary>
        /// Доступ к видеозаписям. 
        /// </summary>
        video = 16,
        /// <summary>
        /// Доступ к предложениям (устаревшие методы). 
        /// </summary>
        offers = 32,
        /// <summary>
        /// Доступ к вопросам (устаревшие методы). 
        /// </summary>
        questions = 64,
        /// <summary>
        /// Доступ к wiki-страницам. 
        /// </summary>
        pages = 128,
        /// <summary>
        /// Добавление ссылки на приложение в меню слева.
        /// </summary>
        link = 256,
        /// <summary>
        /// Доступ заметкам пользователя. 
        /// </summary>
        notes = 2048,
        /// <summary>
        /// (для Standalone-приложений) Доступ к расширенным методам работы с сообщениями. 
        /// </summary>
        messages = 4096,
        /// <summary>
        /// Доступ к обычным и расширенным методам работы со стеной. 
        /// </summary>
        wall = 8192,
        /// <summary>
        /// Доступ к документам пользователя.
        /// </summary>
        docs = 131072
    }
    class Authorize
    {
        static public string AccessToken { get; internal set; }
        static public int UserID { get; internal set; }
        public Authorize()
        {
            AuthDialog ad = new AuthDialog();
            ad.ShowDialog();
            AccessToken = ad.AccessToken;
            UserID = ad.UserID;
        }
    }
}
