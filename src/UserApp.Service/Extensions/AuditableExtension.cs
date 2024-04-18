﻿using UserApp.Domain.Commons;
using UserApp.Service.Helpers;

namespace UserApp.Service.Extensions;

public static class AuditableExtension
{
    public static void Create(this Auditable auditable)
    {
        auditable.CreatedAt = DateTime.UtcNow;
        auditable.CreatedByUserId = HttpContextHelper.UserId;
    }

    public static void Update(this Auditable auditable)
    {
        auditable.UpdatedAt = DateTime.UtcNow;
        auditable.UpdatedByUserId = HttpContextHelper.UserId;
    }

    public static void Delete(this Auditable auditable)
    {
        auditable.DeletedAt = DateTime.UtcNow;
        auditable.DeletedByUserId = HttpContextHelper.UserId;
    }
}
