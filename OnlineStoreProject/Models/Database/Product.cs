﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using OnlineStoreProject.Enums;
using Newtonsoft.Json;
using OnlineStoreProject.Models.Database.SupportClasses;

namespace OnlineStoreProject.Models.Database
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string ProductCode { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public UnitsOfMeasureEnum? UnitOfMeasure { get; set; }

        public decimal? Quantity { get; set; }

        public int? Capacity { get; set; }

        public int? ManufacturerId { get; set; }

        [ForeignKey("ManufacturerId")]
        public Manufacturer? Manufacturer { get; set; }

        public decimal? Price { get; set; }

        public decimal? DiscountPercentage { get; set; }

        public int? ProductCategoryId { get; set; }

        [ForeignKey("ProductCategoryId")]
        public virtual ProductCategory? ProductCategory { get; set; }

        public int WarehouseId { get; set; }

        [ForeignKey("WarehouseId")]
        public virtual Warehouse? Warehouse { get; set; }

        public string? ProductDetails { get; set; }

        public string? AdditionalInfo { get; set; }

        [JsonIgnore]
        public virtual ICollection<MovementHistory> MovementHistories { get; set; }

        [JsonIgnore]
        public virtual ICollection<ShipmentItem> ShipmentItems { get; set; }

        [JsonIgnore]
        public virtual ICollection<ReceiptItem> ReceiptItems { get; set; }

        [JsonIgnore]
        public virtual ICollection<OrderItem> OrderItems { get; set; }

        [JsonIgnore]
        public virtual ICollection<ProductPhoto> ProductPhotos { get; set; }

        [JsonIgnore]
        public virtual ICollection<ProductInZonePosition> ProductsInZonePositions { get; set; }

        [JsonIgnore]
        public virtual ICollection<Label> Labels { get; set; }

        public Product(string productCode, string name, int warehouseId)
        {
            ProductCode = productCode;
            Name = name;
            WarehouseId = warehouseId;

            MovementHistories = new List<MovementHistory>();
            ShipmentItems = new List<ShipmentItem>();
            ReceiptItems = new List<ReceiptItem>();
            OrderItems = new List<OrderItem>();
            ProductPhotos = new List<ProductPhoto>();
            ProductsInZonePositions = new List<ProductInZonePosition>();
            Labels = new List<Label>();
        }

        public Product(string productCode, 
                        string name, 
                        UnitsOfMeasureEnum? unitOfMeasure, 
                        decimal? quantity, 
                        int? capacity, 
                        decimal price, 
                        int warehouseId) : this(productCode, name, warehouseId)
        {
            UnitOfMeasure = unitOfMeasure;
            Quantity = quantity;
            Capacity = capacity;
            Price = price;
        }

        public void AddProductDetail(string key, string value)
        {
            try
            {
                ProductDetail newDetail = new ProductDetail(key, value);
                List<ProductDetail> currentDetails = GetProductDetailsList();
                currentDetails.Add(newDetail);
                ProductDetails = JsonConvert.SerializeObject(currentDetails);
            }
            catch
            {
                throw;
            }
        }

        private List<ProductDetail> GetProductDetailsList()
        {
            try
            {
                if (string.IsNullOrEmpty(ProductDetails))
                {
                    return new List<ProductDetail>();
                }
                else
                {
                    return JsonConvert.DeserializeObject<List<ProductDetail>>(ProductDetails) ?? new List<ProductDetail>();
                }
            }
            //catch (JsonException ex)
            //{
            //    using (var errorLogger = new ErrorLogger(new WarehouseDbContext()))
            //    {
            //        CustomJsonException cex = new CustomJsonException(ex, ProductDetails ?? "");
            //        errorLogger.LogError(cex);
            //    }
            //    return new List<ProductDetail>();
            //}
            catch //(Exception ex)
            {
                //using (var errorLogger = new ErrorLogger(new WarehouseDbContext()))
                //{
                //    errorLogger.LogError(ex);
                //}
                return new List<ProductDetail>();
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
