# Замечания

- при формировании модели EF - первичный ключ называй `Id`, а внешний называешь `Entity + Id` (ProductId, UserId). Это такие соглашения в EF
- лучше и первичный и внешний ключи сделать int, а строковые ключи, которые уже есть в данных просто сделать уникальными и подписать `inventoryNumber`


# Рефакторинг

- конструкцию 

```Csharp
namespace Name {

}
```

можно заменить на `namespace Name;`


- используй первичный конструктор вместо обычного

вместо

```Csharp
    private readonly AppDbContext _context;

    public MaintenanceController(AppDbContext context)
    {
        _context = context;
    }
```

на 

```Csharp
   public class ItemsController(TodoContext todoContext) : ControllerBase
    {
    }
```

- без асинхронности код будет короче, но если понимаешь как писать методы асихронные, то используй

- пакет ` <PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="10.0.1" />` удаляй, лучше только Swagger

```xml
  <PackageReference Include="Swashbuckle.AspNetCore.Swagger" Version="10.1.0"/>
  <PackageReference Include="Swashbuckle.AspNetCore" Version="10.1.0" />
```

-  возможно полезен будет пакет для подписывания endpoins в swagger. Со временем их становиться больше и так будет легче понять

```xml
<PackageReference Include="Swashbuckle.AspNetCore.Annotation" Version="10.1.0" />
```

- подключаем `CORS` в API сразу. Разрешаем origin, methods, header


- в моделях строковое свойство, чтобы не было преупреждений, должно иметь значение по умолчанию 

```Csharp
public int ProductId { get; set; } = string.Empty;
```
Примечание: тип внешнего ключа должен совпадать с типом первичного ключа в другой таблице


- используй команду `dotnet watch` - это `dotnet run` только видит изменения не перезагружая сервер

# Импорт данных из Excel в Dbeaver

- для импорта данных надо подготовить данные в Excel по столбцам в строгом соответствии так, как они идут в базе (перемещение столбцов зажать Shift и навести между столбцами)
- проставить в Excel внешние ключи вместо явных строк
- вставить в Dbeaver командой `Ctrl + Shift + V` и не забыть потом сохранить `Ctrl + S`

# Восстановление базы данных с данными

- после того, как данные будут импортированые сделай dump с данными средствами Dbeaver (База данных - Задачи - Создать задачу)
- в параметрах указать формат Plain, кодировка UTF-8 и поставить Insert Into (первый чекбокс). Это надо для тебя, хотя в задании и критериях этого не требуется

- в Dbeaver сделать полную ERD-диаграмму (ее потом используешь в презентации)

# Check constraint в базе данных через EF

- лучше чистый sql или черзе dbeaver

- через первую миграцию 

AppContext.cs
```Csharp

public class AppContextDb : DbContext{


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(e =>
            e.ToTable(t => t.HasCheckConstraint("checkUserFio", "\"FIO\" != 'test'"))
        );
    }

}
```
Замечание: ограничения создаются только при первой миграции, поэтому их надо создавать сразу, а не после того, как данные импортированы (смысл создания dump базы с данными, чтобы можно было легко восстановить все)

- можно потом на готовой базе данных дописать ограничения на чистом sql


# Git

- коммиты ОБЯЗАТЕЛЬНО делать осмысленными (feature: новая функция, fix: исправил проблему)
- заполнять и оформлять по структуре README

# Enum

 - добавил enum в моделях, в базе они будут храниться как int. При выводе в API можно настроить как числом, так и строкой




# Вопросы

- try catch обработка ошибок нет
- нет данных для логина и пароля, используем свои данные?
- что по Git?
- по поводу десктопного приложения (гибрид, веб-вью). В критериях явно не прописано, в задании написано
- предложения (только нативный десктоп, только веб, общие критерии зачитывать, специальные - только для определенной платформы)
- если запись экрана, то интернет будет?
- использовать только протокол https, или надо самоподписанный сертификат на localhost
- мало баллов за мобильное приложение, его почти обычно не делают
- в создании коллекции postman сказано указать enppoint обновления токена, но в задании и критериях нет про обновление токена


# Приоритет

- drag and drop
- jwt мало

# Библиотеки

## Бекенд

- jwt

## Фронтенд

- пагинация
- отображение: плиткой и таблицей
- dropdown
- sidebar
- jwt через localstorage
- export в csv, pdf, html
- валидация полей при создании (можно на нативном hmtl, можно условием отлючать кнопку и подсвечивать border)
- сортировка и фильтрация на фронтенде (на бекенде не реализуем)
- toast-уведомления в углу
- мультиязычность
- https (генерация самоподписанного сертификата)
- календарь

- react
- react-dom
- react-router
- tailwind
- chart.js (графики и диаграммы)
- toast
- pwa

# Добавить

- логин, пароль, фото
- реализуйте API, которое будет генерировать состояние связи, загрузку, денежные средства и статусы ТА для эмуляции работы
- event для отслеживания событий (возможно, подключить SignalR )


# Hash password

```Csharp
string hashed = BCrypt.Net.BCrypt.HashPassword("пароль");
bool valid = BCrypt.Net.BCrypt.Verify("пароль", hashed);
```

# Пакет

`Microsoft.AspNetCore.Authentication.JwtBearer`


# Тестирование на Linux в колледже


# Jwt for develop only

Это не подойдет для нормальной авторизации, только для проверки точек

- создать appsettings.Development.json
- настроить в Program

```Csharp
builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorization();

...

app.UseAuthentication();
app.UseAuthorization();



```

- dotnet user-jwts
- dotnet user-jwts create --name "VendingApp"
- dotnet user-jwts list
- dotnet user-jwts print id
- защитить endpoint атрибутом [Autothize]
- тестировать через POSTMAN


# Import 

- в Excel файле сделать автоподбор ширины столбцов
- значение по умолчанию в postgres для типа uuid: `gen_random_uuid()`
- методика вставки: сначала создать n - записей, потом выделить все строки без столбца Id и потом `Ctrl + Shift + V` и сохранить
- перезайти в таблицу, чтобы увидеть генерацию uuid для поля Id