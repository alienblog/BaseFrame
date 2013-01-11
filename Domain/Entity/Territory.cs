using System;
using System.Collections;
using System.Collections.Generic;

using Domain.Entity.Base;

namespace Domain.Entity
{
    public partial class Territory : BusinessBase<string>
    {
        #region Declarations

		private string _territoryDescription = String.Empty;
		
		private Region _region = null;
		
		private IList<Employee> _employees = new List<Employee>();
		
		#endregion

        #region Constructors

        public Territory() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_territoryDescription);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

		public virtual string TerritoryDescription
        {
            get { return _territoryDescription; }
			set
			{
				OnTerritoryDescriptionChanging();
				_territoryDescription = value;
				OnTerritoryDescriptionChanged();
			}
        }
		partial void OnTerritoryDescriptionChanging();
		partial void OnTerritoryDescriptionChanged();
		
		public virtual Region Region
        {
            get { return _region; }
			set
			{
				OnRegionChanging();
				_region = value;
				OnRegionChanged();
			}
        }
		partial void OnRegionChanging();
		partial void OnRegionChanged();
		
		public virtual IList<Employee> Employees
        {
            get { return _employees; }
            set
			{
				OnEmployeesChanging();
				_employees = value;
				OnEmployeesChanged();
			}
        }
		partial void OnEmployeesChanging();
		partial void OnEmployeesChanged();
		
        #endregion
    }
}
