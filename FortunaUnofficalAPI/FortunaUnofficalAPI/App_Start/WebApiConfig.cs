using FortunaUnofficalAPI.Models.General;
using FortunaUnofficialAPI.Models.Containers;
using FortunaUnofficialAPI.Models.General;
using FortunaUnofficialAPI.Models.SAF;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web.Http;

namespace FortunaUnofficialAPI
{
    public static class WebApiConfig
    {
        public static object SpeciesAttribute { get; private set; }

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            using (var dataContext = new FortunaDbContext())
            {
                dataContext.SpeciesContainers.Add(
                    new SpeciesContainer()
                    {
                        SpeciesAttributes = new AttributesSpecies()
                        {
                            Diet = "TestDiet",
                            Jobs = "JEBS",
                            LifeSpan = "none",
                            Rarity = "everywhere",
                            SocialClass = "none exsistant"
                        },
                        GenericAttributes = new AttributesGeneric()
                        {
                            Alias = "Alias / Alias",
                            Blurb = "blurb",
                            ArticleCreator = new AttributeCreator()
                            {
                                CreatorName = "name",
                                CreatorUrl = "url"
                            },
                            ArticleRewriter = new AttributeRewriter()
                            {
                                Rewriter = "Rewriter Name",
                                RewriterUrl = "Url"
                            },
                            Name = "TestNme",
                            MainArt = "mainarturl",
                            Quote = "Quote",
                            AltArt = new List<AttributeAltArt> {
                                new AttributeAltArt() {
                                    Description = "desc",
                                    Url = "AltArtURL",
                                    AltArtCreator = new AttributeCreator()
                                    {
                                        Id = Guid.NewGuid(),
                                        CreatorName = "AltArtCreatorName",
                                        CreatorUrl = "AltArtCreatorUrl"
                                    }
                                }
                            }
                        },
                        Url = "MainUrl"
                    }
                );
                dataContext.SaveChanges();
            }


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
