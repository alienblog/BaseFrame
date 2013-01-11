using System;
using System.Collections;
using System.Collections.Generic;

using Domain.Entity.Base;

namespace Domain.Entity
{
    public partial class Product : BusinessBase<int>
    {
        #region Declarations

		private string _productName = String.Empty;
		private string _quantityPerUnit = null;
		private decimal? _unitPrice = null;
		private short? _unitsInStock = null;
		private short? _unitsOnOrder = null;
		private short? _reorderLevel = null;
		private bool _discontinued = default(Boolean);
		
		private Category _category = null;
		private Supplier _supplier = null;
		
		
		#endregion

        #region Constructors

        public Product() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_productName);
			sb.Append(_quantityPerUnit);
			sb.Append(_unitPrice);
			sb.Append(_unitsInStock);
			sb.Append(_unitsOnOrder);
			sb.Append(_reorderLevel);
			sb.Append(_discontinued);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

		public virtual string ProductName
        {
            get { return _productName; }
			set
			{
				OnProductNameChanging();
				_productName = value;
				OnProductNameChanged();
			}
        }
		partial void OnProductNameChanging();
		partial void OnProductNameChanged();
		
		public virtual string QuantityPerUnit
        {
            get { return _quantityPerUnit; }
			set
			{
				OnQuantityPerUnitChanging();
				_quantityPerUnit = value;
				OnQuantityPerUnitChanged();
			}
        }
		partial void OnQuantityPerUnitChanging();
		partial void OnQuantityPerUnitChanged();
		
		public virtual decimal? UnitPrice
        {
            get { return _unitPrice; }
			set
			{
				OnUnitPriceChanging();
				_unitPrice = value;
				OnUnitPriceChanged();
			}
        }
		partial void OnUnitPriceChanging();
		partial void OnUnitPriceChanged();
		
		public virtual short? UnitsInStock
        {
            get { return _unitsInStock; }
			set
			{
				OnUnitsInStockChanging();
				_unitsInStock = value;
				OnUnitsInStockChanged();
			}
        }
		partial void OnUnitsInStockChanging();
		partial void OnUnitsInStockChanged();
		
		public virtual short? UnitsOnOrder
        {
            get { return _unitsOnOrder; }
			set
			{
				OnUnitsOnOrderChanging();
				_unitsOnOrder = value;
				OnUnitsOnOrderChanged();
			}
        }
		partial void OnUnitsOnOrderChanging();
		partial void OnUnitsOnOrderChanged();
		
		public virtual short? ReorderLevel
        {
            get { return _reorderLevel; }
			set
			{
				OnReorderLevelChanging();
				_reorderLevel = value;
				OnReorderLevelChanged();
			}
        }
		partial void OnReorderLevelChanging();
		partial void OnReorderLevelChanged();
		
		public virtual bool Discontinued
        {
            get { return _discontinued; }
			set
			{
				OnDiscontinuedChanging();
				_discontinued = value;
				OnDiscontinuedChanged();
			}
        }
		partial void OnDiscontinuedChanging();
		partial void OnDiscontinuedChanged();
		
		public virtual Category Category
        {
            get { return _category; }
			set
			{
				OnCategoryChanging();
				_category = value;
				OnCategoryChanged();
			}
        }
		partial void OnCategoryChanging();
		partial void OnCategoryChanged();
		
		public virtual Supplier Supplier
        {
            get { return _supplier; }
			set
			{
				OnSupplierChanging();
				_supplier = value;
				OnSupplierChanged();
			}
        }
		partial void OnSupplierChanging();
		partial void OnSupplierChanged();
		
        #endregion
    }
}
