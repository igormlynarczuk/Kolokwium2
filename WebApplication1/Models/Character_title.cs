﻿using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

[Table("Character_title")]
[PrimaryKey(nameof(CharacterId), nameof(TitleId))]
public class Character_title
{
    public int CharacterId { get; set; }
    public int TitleId { get; set; }
    public DateTime AcquiredAt { get; set; }
    
    [ForeignKey(nameof(CharacterId))]
    public Character Character { get; set; } = null!;
    [ForeignKey(nameof(TitleId))]
    public Item Item { get; set; } = null!;
}