services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "DemoAuthApi", Version = "V1" });
                    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                    {
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer",
                        BearerFormat = "JWT",
                        In = ParameterLocation.Header,
                        Description = "Enter 'Bearer'[space] and then your valid token in the text input bellow. \r\n\r\n"
                    });
                    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] { }
                        }

                    });

             });

             app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/Swagger.Json", "DemoAuthApi v1"));
            SingningCredentials: new SingingCredentials(IssuerSigningKey, securityAlgorithms.Hmacsha256)

Appsetting
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Data Source = Contact.DemoDb.DB"
  },
  "JWTSettings": {
    "Issuer" : "Https://securityAPI.org",
    "Audience": "https://security.org",
      "SecretKey":"34jd-bcnsl-skjsflfkld-4556kjldfe"

  }
}
