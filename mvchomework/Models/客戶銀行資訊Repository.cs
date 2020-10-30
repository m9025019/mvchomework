using System;
using System.Linq;
using System.Collections.Generic;

namespace mvchomework.Models
{
	public  class 客戶銀行資訊Repository : EFRepository<客戶銀行資訊>, I客戶銀行資訊Repository
	{
        //public override IQueryable<客戶銀行資訊> All()
        //{
        //    return base.All().Where(p => p.IsDelete == false);
        //}

        public 客戶銀行資訊 Get單一筆部門資料(int id)
        {
            return this.All().FirstOrDefault(p => p.Id == id);
        }

        public override void Delete(客戶銀行資訊 entity)
        {
            entity.IsDelete = true;
        }
    }

	public  interface I客戶銀行資訊Repository : IRepository<客戶銀行資訊>
	{

	}
}