using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
	public interface IIdentifieble<TId>
	{
		[Key]		
		TId Id { get; set; }
	}

	public abstract class BaseEntity<TId> : IIdentifieble<TId>
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public TId Id { get; set; }
	}

	public class OrderHeader : BaseEntity<int>
    {
	    public DateTime Created { get; set; }

		public ICollection<OrderItem> OrderItems { get; set; }
	}

	public class OrderItem : BaseEntity<int>
	{
		public decimal Price { get; set; }

		public OrderHeader OrderHeader { get; set; }
	}
}