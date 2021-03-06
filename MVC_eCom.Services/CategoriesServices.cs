﻿using MVC_eCom.Database;
using MVC_eCom.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MVC_eCom.Services
{
    /// <summary>
    /// 商業邏輯層
    /// </summary>
    public class CategoriesService
    {
        #region Singleton

        public static CategoriesService Instance
        {
            get
            {
                if (instance == null) instance = new CategoriesService();
                return instance;
            }

        }
        private static CategoriesService instance { get; set; }
        private CategoriesService()
        {

        }
        #endregion
        /// <summary>
        /// 找出分類ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Category GetCategory(int ID)
        {
            using (var context = new CBContext())
            {
                return context.Categories.Find(ID);
            }
        }
        /// <summary>
        /// 計算分類總數
        /// </summary>
        /// <param name="search">搜尋</param>
        /// <returns></returns>
        public int GetCategoriesCount(string search)
        {
            using (var context = new CBContext())
            {
                //是否搜尋
                if (!string.IsNullOrEmpty(search))
                {
                    return context.Categories
                        //名字不得為空且英文字轉小寫
                        .Where(category => category.Name != null && category.Name.ToLower()
                        //是否包含轉小寫的搜尋字詞
                        .Contains(search.ToLower()))
                        //計算總數
                        .Count();
                }
                else
                {
                    //若沒有搜尋字詞的話，計算全部分類總數
                    return context.Categories.Count();
                }
            }
        }
        /// <summary>
        /// 所有分類
        /// </summary>
        /// <returns></returns>
        public List<Category> GetAllCategories()
        {
            using (var context = new CBContext())
            {
                return context.Categories.ToList();
            }
        }
        public List<Category> GetCategories(string search, int pageNo)
        {
            int pageSize = 3;
            using (var context = new CBContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return context.Categories.Where(category => category.Name != null && category.Name.ToLower()
                        .Contains(search.ToLower()))
                        .OrderBy(x => x.ID)
                        .Skip((pageNo - 1) * pageSize)
                        .Take(pageSize)
                        .Include(x => x.Products)
                        .ToList();
                }
                else
                {

                    return context.Categories
                            .OrderBy(x => x.ID)
                            .Skip((pageNo - 1) * pageSize)
                            .Take(pageSize)
                            .Include(x => x.Products)
                            .ToList();
                }
            }
        }
        public List<Category> GetFeaturedCategories()
        {
            using (var context = new CBContext())
            {
                return context.Categories.Where(x => x.isFeatured && x.ImageURL != null).ToList();
            }
        }
        public void SaveCategory(Category category)
        {
            using (var context = new CBContext())
            {
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }
        public void UpdateCategory(Category category)
        {
            using (var context = new CBContext())
            {
                context.Entry(category).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void DeleteCategory(int ID)
        {
            using (var context = new CBContext())
            {
                var category = context.Categories.Where(x => x.ID == ID).Include(x => x.Products).FirstOrDefault();
                context.Products.RemoveRange(category.Products);
                context.Categories.Remove(category);
                context.SaveChanges();
            }
        }
    }
}
