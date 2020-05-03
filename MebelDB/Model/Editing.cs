using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MebelDB.Model
{
    class Editing
    {
        public static void EditMaterial(Materials materials)
        {

            Model.MebelEntities mebelEntities = new MebelEntities();
            var material = mebelEntities.Materials
                .Where(c => c.Vendor_code == materials.Vendor_code)
                .FirstOrDefault();
            material.Length = materials.Length;
            material.Unit_measuring = materials.Unit_measuring;
            material.Quantity = materials.Quantity;
            material.Vendor_code = materials.Vendor_code;
            material.Purchase_price = materials.Purchase_price;
            material.GOST = materials.GOST;
            material.Name = materials.Name;
            

            mebelEntities.SaveChanges();
        }

        public static void EditFurniture(Furniture furnitures)
        {
            Model.MebelEntities mebelEntities = new MebelEntities();
            var furniture = mebelEntities.Furniture
                .Where(c => c.Vendor_code == furnitures.Vendor_code)
                .FirstOrDefault();
            furniture.Main_supplier = furnitures.Main_supplier;
            furniture.Unit_measuring = furnitures.Unit_measuring;
            furniture.Quantity = furnitures.Quantity;
            furniture.Vendor_code = furnitures.Vendor_code;
            furniture.Purchase_price = furnitures.Purchase_price;
            furniture.Weight = furnitures.Weight;
            furniture.Name = furnitures.Name;


            mebelEntities.SaveChanges();
        }
    }
}
