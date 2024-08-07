﻿namespace JobFreela.Core.Entities;

public abstract class BaseEntity
{
    protected BaseEntity() { }
    public int Id { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
}
