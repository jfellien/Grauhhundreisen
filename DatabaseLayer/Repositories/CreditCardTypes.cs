using System.Collections.Generic;
using DatabaseLayer.DataObjects;
using System.Linq;

namespace DatabaseLayer.Repositories
{

	public class CreditCardTypes{
	
		public IEnumerable<CreditCardType> GetAll(){
			var ccTypes = new List<CreditCardType>{ 
				new CreditCardType{Name="Master Card"},
				new CreditCardType{Name="Visa"},
				new CreditCardType{Name="American Express"}
			};

			return ccTypes.OrderBy (ccType => ccType.Name);
		}
	}
}
