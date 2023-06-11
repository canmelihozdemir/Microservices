// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;

namespace FreeCourse.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("resource_catalog"){Scopes={"catalog_fullpermission"}},
            new ApiResource("resource_photo_stock"){Scopes={"photo_stock_fullpermssion"}},
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)


        };



        public static IEnumerable<IdentityResource> IdentityResources =>
                new IdentityResource[]
                {
                    new IdentityResources.Email(),
                    new IdentityResources.OpenId(),
                    new IdentityResources.Profile(),
                    new IdentityResource(){Name="roles",DisplayName="Roles",Description="Kullanıcı Rolleri",UserClaims=new[]{"role"}}
                };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("catalog_fullpermission","Full access for Catalog API"),
                new ApiScope("photo_stock_fullpermssion","Full access for Photo Stock API"),
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName)

            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientName="Asp.Net Core MVC Test",
                    ClientId="WebMvcClientTest",
                    ClientSecrets={new Secret("secretTest".Sha256())},
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    AllowedScopes={ "catalog_fullpermission", "photo_stock_fullpermssion", IdentityServerConstants.LocalApi.ScopeName }
                },
                new Client
                {
                    ClientName="Asp.Net Core MVC Test",
                    ClientId="WebMvcClientTestForUser",
                    ClientSecrets={new Secret("secretTest".Sha256())},
                    AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                    AllowedScopes={ IdentityServerConstants.StandardScopes.Email, IdentityServerConstants.StandardScopes.OpenId, IdentityServerConstants.StandardScopes.Profile, IdentityServerConstants.StandardScopes.OfflineAccess,"roles" },
                    AccessTokenLifetime=1*60*60,
                    RefreshTokenExpiration=TokenExpiration.Absolute,
                    AbsoluteRefreshTokenLifetime=(int)(DateTime.Now.AddDays(60)-DateTime.Now).TotalSeconds,
                    RefreshTokenUsage=TokenUsage.ReUse
                }
            };
    }
}