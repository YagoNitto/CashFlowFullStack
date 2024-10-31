﻿using Dima.Core.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dima.Core.Requests.Transactions;
public class CreateTransactionRequest : Request
{
    [Required(ErrorMessage = "Título inválido.")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Tipo inválido.")]
    public ETransactionType Type { get; set; } = ETransactionType.Withdraw;
    [Required(ErrorMessage = "Valor inválido.")]
    public decimal Amount { get; set; }
    [Required(ErrorMessage = "Categoria inválida.")]
    public Guid CategoryId { get; set; }
    [Required(ErrorMessage = "Data inválida.")]
    public DateTime? PaidOrReceivedAt { get; set; } = DateTime.Today;
}
