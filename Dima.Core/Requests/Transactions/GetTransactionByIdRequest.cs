﻿namespace Dima.Core.Requests.Transactions;
public class GetTransactionByIdRequest : Request
{
    public Guid Id { get; set; }
}
