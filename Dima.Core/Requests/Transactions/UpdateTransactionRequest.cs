﻿using Dima.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Dima.Core.Requests.Transactions;
public class UpdateTransactionRequest : Request
{
    public Guid Id { get; set; }
    [Required(ErrorMessage = "Título inválido.")]
    public string Title { get; set; } = string.Empty;
    [Required(ErrorMessage = "Tipo inválido.")]
    public ETransactionType Type { get; set; }
    [Required(ErrorMessage = "Valor inválido.")]
    public decimal Amount { get; set; }
    [Required(ErrorMessage = "Categoria inválida.")]
    public Guid CategoryId { get; set; }
    [Required(ErrorMessage = "Data inválida.")]
    public DateTime? PaidOrReceivedAt { get; set; }
}