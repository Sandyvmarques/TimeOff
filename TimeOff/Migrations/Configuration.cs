namespace TimeOff.Migrations
{
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
                new Utilizador {Id=1,UserName = "RGocalves", DataNasc = new DateTime(1996,5,3), NomeCompleto = "Rafael André Campos Gonçalves", Email = "racggoncalves@gmail.com", Sexo = "Masculino"},
                new Utilizador {Id=2,UserName = "TGoncalves", DataNasc = new DateTime(1992,4,11) , NomeCompleto = "Tiago Jorge Campos Gonçalves", Email = "tjorge@gmail.com", Sexo = "Masculino"},
                new Utilizador {Id=3,UserName = "Symao96", DataNasc = new DateTime(1996,10,2) , NomeCompleto = "Simão Pedro Oliveira Moleiro", Email = "symao96@gmail.com", Sexo = "Masculino" },
                new Utilizador {Id=4,UserName = "Bokica", DataNasc = new DateTime(1995,7,2), NomeCompleto = "Beatriz Bangurá da Silva Okica de Sá", Email = "beatrizbokica@gmail.com", Sexo = "Femenina"},
                new Utilizador {Id=5,UserName = "Pfaustino", DataNasc = new DateTime(1995,10,2) , NomeCompleto = "Praticia Sofia Margalhães Faustino", Email = "patricia.sofia.faustino@gmail.com", Sexo = "Feminina"},
                new Utilizador {Id=6,UserName = "Mandreia", DataNasc = new DateTime(1997,8,22) , NomeCompleto = "Marta Andreia Campos Ribeiro", Email = "Mandreia@gmail.com", Sexo = "Femenino"},
            };

            user.ForEach(dd => context.Utilizador.AddOrUpdate(d => d.UserName, dd));
            context.SaveChanges();

            //Realizador
            var directors = new List<Realizador>
            {
                new Realizador {Id=1, Nome = "David Ayer", DataNasc = new DateTime(1968,1,18) , Biografia = "David Ayer foi expulso de casa pelos seus pais durante a adolescência, tendo-se instalado em Los Angeles, Califórnia, com o seu primo. As suas experiências no bairro de South Central são uma fonte de inspiração para os seus filmes, cuja ação se desenrola frequentemente neste espaço."},
                new Realizador {Id=2, Nome = "David Yates", DataNasc = new DateTime(1963,10,8) , Biografia = "David Yates é um diretor de televisão e cinema britânico. Ele é mais famoso por dirigir os quatro últimos filmes da franquia Harry Potter: Order of the Phoenix, Half-Blood Prince e Deathly Hallows partes I e II e a série spin-off, Animais Fantásticos e Onde Habitam."},
                new Realizador {Id=3, Nome = "James Mangold", DataNasc = new DateTime(1963,11,16) , Biografia = "James Mangold é um diretor e roteirista estadunidense." },
                new Realizador {Id=4, Nome = "Dennis Gansel", DataNasc = new DateTime(1973,10,4) , Biografia = "Dennis Gansel é um diretor de cinema, escritor e ator da Alemanha."},
                new Realizador {Id=5, Nome = "Thea Sharrock", DataNasc = new DateTime(1976,1,1) , Biografia = "Thea Sharrock é uma diretora de cinema inglês. Em 2001, quando aos 24 anos ela se tornou diretora artística de Southwark Playhouse em Londres, ela foi a mais jovem diretora artística do teatro britânico." },
            };
            directors.ForEach(dd => context.Realizador.AddOrUpdate(d => d.Nome, dd));
            context.SaveChanges();

            //filme
            var film = new List<Filme>
            {
                new Filme {Id=1,Titulo = "Suicide Squad", Sinopse = "Um grupo de conhecidos super-vilões é recrutado pelo governo americano com o objectivo de executar uma missão demasiado perigosa para ser entregue a super-heróis. Habituados a trabalhar por conta própria, os vilões são forçados a superar antigos conflitos e metas individuais para trabalharem em equipa. Em troca, o governo promete-lhes perdão...", AnoLanc = 2016,LinkTrailer="wwww.xcfv.com", RealizadorId = 1},
                new Filme {Id=2,Titulo = "Fantastic Beasts and Where to Find Them", Sinopse = "As aventuras de Newt Scamander no seio da comunidade secreta de bruxas e feiticeiros de Nova Iorque, 70 anos antes da chegada de Harry Potter a Hogwarts.", AnoLanc = 2016, LinkTrailer="", RealizadorId = 2},
                new Filme {Id=3,Titulo = "Logan", Sinopse = "No futuro, um exausto Logan, escondido na fronteira Mexicana, cuida do adoentado Professor X. Mas as tentativas de Logan para se esconder do mundo e do seu próprio legado, acabam quando uma jovem mutante chega, sendo perseguida por forças obscuras.", AnoLanc = 2017, LinkTrailer="", RealizadorId = 3},
                new Filme {Id=4,Titulo = "Mechanic: Resurrection", Sinopse = "Justamente quando Arthur Bishop julgava que os seus dias como assassino eram coisa do passado, é forçado a voltar ao ativo quando Gina, o amor da sua vida, é raptada pelo seu mais perigoso inimigo. Agora Arthur tem de viajar pelo globo para completar três impossíveis assassinatos, onde estão os nomes dos mais perigosos homens do mundo, e ainda fazer com que eles pareçam acidentes.", AnoLanc =2016 ,LinkTrailer="", RealizadorId = 4},
                new Filme {Id=5,Titulo = "Me Before You", Sinopse = "Louisa “Lou” Clark vive numa pitoresca vila no campo, em Inglaterra. Sem um rumo definido na sua vida, a excêntrica e criativa jovem de 26 anos anda de trabalho em trabalho, para poder ajudar a sua unida família a pagar as contas. Porém, a sua habitual visão alegre da vida é posta à prova quando enfrenta o mais recente desafio da sua carreira. Ao aceitar um emprego numa mansão local, ela torna-se na assistente domiciliária e companhia de Will Traynor, um jovem e abastado banqueiro que fica numa cadeira de rodas após um acidente ocorrido há dois anos, cujo mundo muda bruscamente num piscar de olhos. Deixando de ser a alma aventureira de outros tempos, o agora cínico Will praticamente desistiu de tudo. Mas algo muda quando Lou decidir mostrar-lhe que a vida merece ser vivida. Embarcando os dois numa série de aventuras, tanto Lou como Will encontram mais do que esperavam e veem as suas vidas – e corações – mudarem de maneiras que nunca poderiam ter imaginado.", AnoLanc =2016, LinkTrailer="", RealizadorId = 5},
            };

            film.ForEach(dd => context.Filme.AddOrUpdate(d => d.Titulo, dd));
            context.SaveChanges();
            //Categorias 

            var category = new List<Categorias>
            {
                new Categorias {Id=1, Nome = "Ação" },
                new Categorias {Id=2, Nome = "Animação"},
                new Categorias {Id=3, Nome = "Comédia"},
                new Categorias {Id=4, Nome = "Drama"},
                new Categorias {Id=5, Nome = "Terror"},
                new Categorias {Id=6, Nome = "Ficção"},
            };

            category.ForEach(dd => context.Categorias.AddOrUpdate(d => d.Nome, dd));
            context.SaveChanges();

            //Comentários 

            var comments = new List<Comentarios>
            {
                new Comentarios { Texto ="Muito bom", Data = new DateTime(2016,10,1), UtilizadorId=1, FilmeId =1},
                new Comentarios { Texto ="Adorei!", Data = new DateTime(2017,5,7), UtilizadorId=2, FilmeId =2},
                new Comentarios { Texto ="Criei uma prespetiva errada do filme", Data = new DateTime(2017,4,2), UtilizadorId=3, FilmeId =3},
                new Comentarios { Texto ="Muito mau", Data = new DateTime(2016,10,1), UtilizadorId=4, FilmeId =4},
                new Comentarios { Texto ="Razoável!", Data = new DateTime(2017,5,7), UtilizadorId=5, FilmeId =5},
                new Comentarios { Texto ="Não gostei muito", Data = new DateTime(2017,4,2), UtilizadorId=6, FilmeId =6},
            };
            comments.ForEach(dd => context.Comentarios.AddOrUpdate(d => d.Texto, dd));
            context.SaveChanges();

            //Comentários 

            var image = new List<Imagens>
            {
                new Imagens { Id=1, Imagem ="", FilmeId =1},
                new Imagens { Id=2, Imagem ="",  FilmeId =2},
                new Imagens { Id=3, Imagem ="", FilmeId =3},
                new Imagens { Id=4, Imagem ="", FilmeId =4},
                new Imagens { Id=5, Imagem ="", FilmeId =5},
                new Imagens { Id=6, Imagem ="",  FilmeId =6},
            };
            comments.ForEach(dd => context.Comentarios.AddOrUpdate(d => d.Texto, dd));
            context.SaveChanges();
        }
    }
}
