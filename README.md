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