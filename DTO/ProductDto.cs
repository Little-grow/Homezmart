﻿namespace Homezmart.DTO
{
    public class ProductDto
    {
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public float Price { get; set; }
        public int StockQuantity { get; set; }
    }
}
