﻿namespace UserApp.Domain.Commons;

public abstract class Auditable
{
    public long Id { get; set; }    
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set;}
    public DateTime? DeletedAt { get; set; }
    public bool IsDeleted { get; set; }
    public long? UpdatedByUserId { get; set; }
    public long CreatedByUserId { get; set; }
    public long? DeletedByUserId { get; set; }
}