namespace TimeOff.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TimeOff.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TimeOff.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TimeOff.Models.ApplicationDbContext context)
        {

            //seed
            //utilizador
            var user = new List<Utilizador> {
                new Utilizador {Id=1, DataNasc = new DateTime(1996,5,3), NomeCompleto = "Rafael André Campos Gonçalves", Email = "racggoncalves@gmail.com", Sexo = "Muito pouco" },
                new Utilizador {Id=2, DataNasc = new DateTime(1992,4,11) , NomeCompleto = "Tiago Jorge Campos Gonçalves", Email = "tjorge@gmail.com", Sexo = "Masculino"},
                new Utilizador {Id=3, DataNasc = new DateTime(1996,10,2) , NomeCompleto = "Simão Pedro Oliveira Moleiro", Email = "symao96@gmail.com", Sexo = "Masculino" },
                new Utilizador {Id=4, DataNasc = new DateTime(1995,7,2), NomeCompleto = "Beatriz Bangurá Okica de Sá", Email = "beatrizbokica@gmail.com", Sexo = "Femenina"},
                new Utilizador {Id=5, DataNasc = new DateTime(1995,10,2) , NomeCompleto = "Patricia Sofia Margalhães Faustino", Email = "patricia.sofia.faustino@gmail.com", Sexo = "Feminina"},
                new Utilizador {Id=6, DataNasc = new DateTime(1997,8,22) , NomeCompleto = "Marta Andreia Campos Ribeiro", Email = "Mandreia@gmail.com", Sexo = "Femenino"},
            };

            user.ForEach(dd => context.Utilizador.AddOrUpdate(d => d.Id, dd));
            context.SaveChanges();

            var storeR = new RoleStore<IdentityRole>(context);
            var managerR = new RoleManager<IdentityRole>(storeR);

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var role = new IdentityRole { Name = "Admin" };

                managerR.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "Viewer"))
            {
                var role = new IdentityRole { Name = "Viewer" };

                managerR.Create(role);
            }

            /////////////////////////// USERS ///////////////////////////////////
            var store = new UserStore<ApplicationUser>(context);
            var manager = new UserManager<ApplicationUser>(store);
            /////////////////////////// ADMIN ///////////////////////////////////
            var us = user[0];
            if (!context.Users.Any(u => u.UserName == us.Email))
            {
                var u = new ApplicationUser
                {
                    UserName = us.Email,
                    Email = us.Email
                };

                manager.Create(u, "123qweQWE#");
                manager.AddToRole(u.Id, "Admin");
            }

            for (int i =1;i< user.Count();i++)
            {
                var us2 = user[i];
                if (!context.Users.Any(u => u.UserName == us2.Email))
                {
                    var u = new ApplicationUser
                    {
                        UserName = us2.Email,
                        Email = us2.Email
                    };

                    manager.Create(u, "123qweQWE#");
                    manager.AddToRole(u.Id, "Viewer");
                }
            }


            //Realizador
            var directors = new List<Realizador>
            {
                new Realizador {Id=1, NomeRealizador = "David Ayer",ImagemRealizador="1.jpg", DataNasc = new DateTime(1968,1,18) , Biografia = "David Ayer foi expulso de casa pelos seus pais durante a adolescência, tendo-se instalado em Los Angeles, Califórnia, com o seu primo. As suas experiências no bairro de South Central são uma fonte de inspiração para os seus filmes, cuja ação se desenrola frequentemente neste espaço."},
                new Realizador {Id=2, NomeRealizador = "David Yates",ImagemRealizador="2.jpg", DataNasc = new DateTime(1963,10,8) , Biografia = "David Yates é um diretor de televisão e cinema britânico. Ele é mais famoso por dirigir os quatro últimos filmes da franquia Harry Potter: Order of the Phoenix, Half-Blood Prince e Deathly Hallows partes I e II e a série spin-off, Animais Fantásticos e Onde Habitam."},
                new Realizador {Id=3, NomeRealizador = "James Mangold",ImagemRealizador="3.jpg", DataNasc = new DateTime(1963,11,16) , Biografia = "James Mangold é um diretor e roteirista estadunidense." },
                new Realizador {Id=4, NomeRealizador = "Dennis Gansel", ImagemRealizador="4.jpg", DataNasc = new DateTime(1973,10,4) , Biografia = "Dennis Gansel é um diretor de cinema, escritor e ator da Alemanha."},
                new Realizador {Id=5, NomeRealizador = "Thea Sharrock", ImagemRealizador="5.jpg",DataNasc = new DateTime(1976,1,1) , Biografia = "Thea Sharrock é uma diretora de cinema inglês. Em 2001, quando aos 24 anos ela se tornou diretora artística de Southwark Playhouse em Londres, ela foi a mais jovem diretora artística do teatro britânico." },
            };
            directors.ForEach(dd => context.Realizador.AddOrUpdate(d => d.Id, dd));
            context.SaveChanges();
            //Categorias 

            var category = new List<Categorias>
            {
                new Categorias {Id=1, Nome = "Ação"},
                new Categorias {Id=2, Nome = "Animação"},
                new Categorias {Id=3, Nome = "Comédia"},
                new Categorias {Id=4, Nome = "Drama"},
                new Categorias {Id=5, Nome = "Terror"},
                new Categorias {Id=6, Nome = "Ficção"},
                new Categorias {Id=7, Nome = "Aventura"},
                new Categorias {Id=8, Nome = "Fantasia"},
                new Categorias {Id=9, Nome = "Familiar"},
                new Categorias {Id=10, Nome = "Crime"},
                new Categorias {Id=11, Nome = "Romance"},


            };

            category.ForEach(dd => context.Categorias.AddOrUpdate(d => d.Id, dd));
            context.SaveChanges();
            //filme
            var film = new List<Filme>
            {
                new Filme {Id=1,Titulo = "Suicide Squad", ImagensFilme="suicideSquad.jpg", Sinopse = "Um grupo de conhecidos super-vilões é recrutado pelo governo americano com o objectivo de executar uma missão demasiado perigosa para ser entregue a super-heróis. Habituados a trabalhar por conta própria, os vilões são forçados a superar antigos conflitos e metas individuais para trabalharem em equipa. Em troca, o governo promete-lhes perdão...", AnoLanc = 2016,LinkTrailer="https://www.youtube.com/embed/CmRih_VtVAs", RealizadorId = 1,Categorias= new List<Categorias>{category[0],category[6],category[7]}},
                new Filme {Id=2,Titulo = "Fantastic Beasts and Where to Find Them",ImagensFilme="FantasticBeast.jpg", Sinopse = "As aventuras de Newt Scamander no seio da comunidade secreta de bruxas e feiticeiros de Nova Iorque, 70 anos antes da chegada de Harry Potter a Hogwarts.", AnoLanc = 2016, LinkTrailer="https://www.youtube.com/embed/Vso5o11LuGU", RealizadorId = 2, Categorias= new List<Categorias>{category[8],category[6],category[7]}},
                new Filme {Id=3,Titulo = "Logan", ImagensFilme="logan.jpg", Sinopse = "No futuro, um exausto Logan, escondido na fronteira Mexicana, cuida do adoentado Professor X. Mas as tentativas de Logan para se esconder do mundo e do seu próprio legado, acabam quando uma jovem mutante chega, sendo perseguida por forças obscuras.", AnoLanc = 2017, LinkTrailer="https://www.youtube.com/embed/Div0iP65aZo", RealizadorId = 3,Categorias= new List<Categorias>{category[0],category[3],category[5]}},
                new Filme {Id=4,Titulo = "Mechanic: Resurrection", ImagensFilme="mechanic.jpg", Sinopse = "Justamente quando Arthur Bishop julgava que os seus dias como assassino eram coisa do passado, é forçado a voltar ao ativo quando Gina, o amor da sua vida, é raptada pelo seu mais perigoso inimigo. Agora Arthur tem de viajar pelo globo para completar três impossíveis assassinatos, onde estão os nomes dos mais perigosos homens do mundo, e ainda fazer com que eles pareçam acidentes.", AnoLanc =2016 ,LinkTrailer="https://www.youtube.com/embed/G-P3f_wDXvs", RealizadorId = 4, Categorias= new List<Categorias>{category[0],category[7],category[9]}},
                new Filme {Id=5,Titulo = "Me Before You", ImagensFilme="mebeforeyou.jpg", Sinopse = "Louisa “Lou” Clark vive numa pitoresca vila no campo, em Inglaterra. Sem um rumo definido na sua vida, a excêntrica e criativa jovem de 26 anos anda de trabalho em trabalho, para poder ajudar a sua unida família a pagar as contas. Porém, a sua habitual visão alegre da vida é posta à prova quando enfrenta o mais recente desafio da sua carreira. Ao aceitar um emprego numa mansão local, ela torna-se na assistente domiciliária e companhia de Will Traynor, um jovem e abastado banqueiro que fica numa cadeira de rodas após um acidente ocorrido há dois anos, cujo mundo muda bruscamente num piscar de olhos. Deixando de ser a alma aventureira de outros tempos, o agora cínico Will praticamente desistiu de tudo. Mas algo muda quando Lou decidir mostrar-lhe que a vida merece ser vivida. Embarcando os dois numa série de aventuras, tanto Lou como Will encontram mais do que esperavam e veem as suas vidas – e corações – mudarem de maneiras que nunca poderiam ter imaginado.", AnoLanc =2016, LinkTrailer="https://www.youtube.com/embed/Eh993__rOxA", RealizadorId = 5,Categorias= new List<Categorias>{category[3],category[10]}},
            };

            film.ForEach(dd => context.Filme.AddOrUpdate(d => d.Id, dd));
            context.SaveChanges();
            

            //Comentários 
            var comments = new List<Comentarios>
            {
                new Comentarios { Texto ="Muito bom", Data = new DateTime(2016,10,1), UtilizadorId=1, FilmeId =1},
                new Comentarios { Texto ="Adorei!", Data = new DateTime(2017,5,7), UtilizadorId=2, FilmeId =2},
                new Comentarios { Texto ="Criei uma prespetiva errada do filme", Data = new DateTime(2017,4,2), UtilizadorId=3, FilmeId =3},
                new Comentarios { Texto ="Muito mau", Data = new DateTime(2016,10,1), UtilizadorId=4, FilmeId =4},
                new Comentarios { Texto ="Razoável!", Data = new DateTime(2017,5,7), UtilizadorId=5, FilmeId =5},
                new Comentarios { Texto ="Não gostei muito", Data = new DateTime(2017,4,2), UtilizadorId=6, FilmeId =5},
            };
            comments.ForEach(dd => context.Comentarios.AddOrUpdate(d => d.Texto, dd));
            context.SaveChanges();


            //Atores
            var atores = new List<Ator>
            {
                new Ator { Id=1, Nome="Margot Robbie", Filmes=new List<Filme> { film[0]}},
                new Ator { Id=2, Nome="Jared Leto", Filmes=new List<Filme> { film[0] }},
                new Ator { Id=3, Nome="Will Smith", Filmes=new List<Filme> {film[0] }},
                new Ator { Id=4, Nome="Hugh Jackman", Filmes=new List<Filme> {film[2] }},
                new Ator { Id=5, Nome="Patrick Stewart", Filmes=new List<Filme> {film[2] }},
                new Ator { Id=6, Nome="Emilia Clarke", Filmes=new List<Filme> { film[4] }},
                new Ator { Id=7, Nome="Sam Claflin", Filmes=new List<Filme> { film[4] }},
                new Ator { Id=8, Nome="Jason Statham", Filmes=new List<Filme> { film[3] }},
                new Ator { Id=9, Nome="Jessica Alba", Filmes=new List<Filme> { film[3] }},
                new Ator { Id=10, Nome="Eddie Redmayne", Filmes=new List<Filme> { film[1] }},
                new Ator { Id=11, Nome="Katherine Waterston", Filmes=new List<Filme> { film[1] }},
            };
            atores.ForEach(dd => context.Ators.AddOrUpdate(d => d.Id, dd));
            context.SaveChanges();
        }
    }
}
