using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BankATM.DataAccess.EF.Models;

[Table("CustomersInfo")]
public partial class CustomersInfo
{

    [Key]
    [Column("CustomerID")]
    public int CustomerId { get; set; }

    public int AccountNumber { get; set; }

    [Column("FIrstName")]
    [StringLength(255)]
    [Unicode(false)]
    public string? FirstName { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? LastName { get; set; }

    public int? PinNumber { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Balance { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal DepositAmount { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal WithdrawAmount { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal NewBalance { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TransactionDate { get; set; }
}
