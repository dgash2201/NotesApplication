# ParadoxTestTask

**Инструкция по запуску**

Для запуска приложения потребуется установить:

.NET 7.0.17 <https://dotnet.microsoft.com/en-us/download/dotnet/7.0>

CУБД PostgreSQL <https://www.enterprisedb.com/downloads/postgres-postgresql-downloads>

Visual Studio 2022 с компонентом «ASP.NET and web development» (опционально)


**1.** Создать базу данных в PostgreSQL

**2.** Скопировать проект себе на компьютер из github по ссылке <https://github.com/dgash2201/ParadoxTestTask>

**3.** Открыть папку проекта в powershell и выполнить команду **dotnet restore**

Либо в Visual Studio нажать ПКМ на название решения и нажать «Restore NuGet Packages»


**4.** Зайти в папку проекта NotesApplication.API и открыть файл appsettings.json. Далее в объекте «ConnectionStrings» для свойства «DefaultConnection» задать строку подключения к ранее созданной базе данных в формате "Host=*<сервер\_БД>*;Port=*<номер\_порта\_сервера\_БД>*;Database=*<название\_БД>*;Username=*<имя\_пользователя>*;Password=*<пароль\_БД>*"


**5)** Далее нужно установить средства для работы с Entity Framework, выполнив команду **dotnet tool install --global dotnet-ef --version 7.0.17**

При использовании Visual Studio этот шаг можно пропустить

**6)** Выполняем обновление БД с помощью миграций

Либо в powershell c помощью команды **dotnet ef database update --project NotesApplication.Infrastructure --startup-project NotesApplication.API**

Либо в Visual Studio 2022 в окне Package Manager Console выполняем команду **Update-Database -Project NotesApplication.Infrastructure**


**7)** Запускаем проект с помощью команды **dotnet run --project NotesApplication.API**

Или в Visual Studio

**8.** Открываем ссылку <https://localhost:7207/swagger/index.html> где можно ознакомиться с API приложения