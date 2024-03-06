using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Tracker_Application
{
    static class CategoryManager
    {

        public static List<string> categoryNameList = new List<string>();

        public static int curId = 4;

        

        public static void AddCategory(string name, int limit)
        {
            //CategoryData data = new CategoryData()
            //{
            //    categoryId = curId++,
            //    name = name,
            //    limit = limit
            //};

            categoryNameList.Add(name);
        }
        public static void RemoveCategory(string selectedName)
        {


            

            for (int ind = 0; ind < categoryNameList.Count; ind++)
            {
                if (categoryNameList[ind] == selectedName)
                {
                    categoryNameList.RemoveAt(ind);


                    break;
                }
            }
        }
        public static void ModifyCategory(int selectedId, int modifiedLimit)
        {
            //for (int ind = 0; ind < CategoryManager.categoryList.Count; ind++)
            //{
            //    if (CategoryManager.categoryList[ind].categoryId == selectedId)
            //    {
            //        CategoryManager.categoryList[ind].limit = modifiedLimit;
            //    }
            //}
        }

    }
}
