using System;
using System.Linq;
using System.Collections.Generic;

namespace mvchomework.Models
{
	public  class 客戶資料Repository : EFRepository<客戶資料>, I客戶資料Repository
	{
        public 客戶資料 Get單一筆部門資料(int id)
        {
            return this.All().FirstOrDefault(p => p.Id == id);
        }

        public override void Delete(客戶資料 entity)
        {
            entity.IsDelete = true;
        }
    }

	public  interface I客戶資料Repository : IRepository<客戶資料>
	{

	}
}