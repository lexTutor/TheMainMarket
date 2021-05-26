using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TheMainMarket.Models;

namespace TheMainMarket.DataAccess.EntityConfigurations
{
    public class EntityConfigurationForTokens : IEntityTypeConfiguration<Token>
    {
        public void Configure(EntityTypeBuilder<Token> builder)
        {
            builder.HasOne(token => token.User)
                    .WithMany(users => users.Tokens)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
