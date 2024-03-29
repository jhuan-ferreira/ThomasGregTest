Documentação do Projeto

Projeto desenvolvido utilizando ASP.NET Framework 4.8, com ORM Entity Framwork para realizar a persistência de dados no banco de dados SQL Server 2016.  
Para a autenticação dos End-Points das API’s foi utilizado o tipo ‘Bearer’, onde o token está sendo gerado por meio das bibliotecas Microsoft.Owin.  
 
O Projeto foi desenvolvido seguindo a arquitetura MVVM (Model, View, ViewModel). Com a separação de camadas, onde a primeira camada ‘API’ contém as controllers e views das API’s. a segunda camada ‘Busines’, contém as regras do negócio, a terceira camada ‘Data’ contém toda a infraestrutura de comunicação com o banco de dados, interfaces, repositórios, entidades e mapeamento das entidades e a quarta camada ‘ViewModels’ contém as View-Models necessárias.  
Na camada de “ThomasGregTest .Data” deste projeto há uma pasta com a nomenclatura “Script DB” 
nela contém os scripts necessários para gerar as tabelas ‘Cliente’ e ‘Logradouro’ no seu banco de dados será necessário executar estes scripts para que o seu banco de dados tenha a estrutura correta para o funcionamento da aplicação.  
 
  
 
Após rodar o script será necessário alterar a string de conexão com o banco de dados, poderá alterar a string acessando a camada “ThomasGregTest.Data” do projeto no arquivo App.Config, na linha 16 na propriedade ‘connectionString’ no espaço das aspas vazias, você coloca sua string de conexão.

 

Também será necessário definir a camada ‘ThomasGregTest.API’ como projeto de inicialização. Clique com o botão direito na camada, selecione a opção “Definir como Projeto de Inicialização”.

