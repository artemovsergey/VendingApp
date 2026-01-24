# Настройка

## API

- смотрит на версию .net
- пакет ` <PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="10.0.1" />` убираем

- установка Swagger
```xml
  <PackageReference Include="Swashbuckle.AspNetCore.Swagger" Version="10.1.0"/>
  <PackageReference Include="Swashbuckle.AspNetCore" Version="10.1.0" />
  <PackageReference Include="Swashbuckle.AspNetCore.Annotation" Version="10.1.0" />
```

- подключаем `CORS` в API сразу. Разрешаем origin, methods, header
- используй команду `dotnet watch` - это `dotnet run` только видит изменения не перезагружая сервер


# Импорт данных из Excel в Dbeaver

- для импорта данных надо подготовить данные в Excel по столбцам в строгом соответствии так, как они идут в базе (перемещение столбцов зажать Shift и навести между столбцами)
- проставить в Excel внешние ключи вместо явных строк
- вставить в Dbeaver командой `Ctrl + Shift + V` и не забыть потом сохранить `Ctrl + S`
- смотреть в данных на первичные ключи: int Id или Guid Id

# Восстановление базы данных с данными

- после того, как данные будут импортированые сделай dump с данными средствами Dbeaver (База данных - Задачи - Создать задачу)
- в параметрах указать формат Plain, кодировка UTF-8 и поставить Insert Into (первый чекбокс). Это надо для тебя, хотя в задании и критериях этого не требуется
- в Dbeaver сделать полную ERD-диаграмму (ее потом используешь в презентации)
- лучше constraint через чистый sql или через dbeaver
- коммиты ОБЯЗАТЕЛЬНО делать осмысленными (feature: новая функция, fix: исправил проблему)
- заполнять и оформлять по структуре README
 - добавил enum в моделях, в базе они будут храниться как int. При выводе в API можно настроить как числом, так и строкой. При таком подходе в коде становиться легче ориентироваться

# Вопросы и предложения

- можно доабвить в ресурсы цветовую палитру
- надо добавить данные по инкассации
- блоке новости: Это будет внешний API?
- try catch обработка ошибок нет
- нет данных для логина и пароля, используем свои данные?
- что по Git?
- по поводу десктопного приложения (гибрид, веб-вью). В критериях явно не прописано, в задании написано
- предложения (только нативный десктоп, только веб, общие критерии зачитывать, специальные - только для определенной платформы)
- использовать только протокол https, или надо самоподписанный сертификат на localhost
- тестирование на Linux в колледже
- точки на minimalAPI
- в Excel файле сделать автоподбор ширины столбцов
- значение по умолчанию в postgres для типа uuid: `gen_random_uuid()`
- методика вставки: сначала создать n - записей, потом выделить все строки без столбца Id и потом `Ctrl + Shift + V` и сохранить
- перезайти в таблицу, чтобы увидеть генерацию uuid для поля Id
- hash password

```Csharp
string hashed = BCrypt.Net.BCrypt.HashPassword("пароль");
bool valid = BCrypt.Net.BCrypt.Verify("пароль", hashed);
```

- авторизация по логин и паролю без jwt: создать AuthController и модель Dto с Login и Password, добавить в модель User новые поля, провести миграцию
- endpoint авторизации с проверкой хеша
- endpoint регистрации через метод создания пользователя с хешированием
- установить на windows/linux `mkcert`
- mkcert install
- mkcert localhost

GET /vendingMachines
GET /vendingMachines/{id}
PUT /vendingMachines
DELETE /vendingMachines
GET /vendingMachines/{id}/link/{modemId}
GET /vendingMachines/{id}/unlink/{modemId}

- npx create-vite@latest
- выбрать react и typescript (может и без ts)
- удалить стандартные css стили из App.css и index.css
- проверить работу App.tsx
- установить tailwindcss
- настроить в vite.config
- подключить стили tailwind
- проверить работу
- сделать разметку на компонентах через tailwind
- для react 19: `npm install react-router-dom@latest -force`, если не установиться


- pwa

```ts
export default defineConfig({
  plugins: [
    react(),
    tailwindcss(),
    VitePWA({
      registerType: 'autoUpdate',
      devOptions: {
        enabled: true
      },
      manifest: {
        name: "Мое Приложение",
        short_name: "Приложение",
        description: "Мое React PWA",
        start_url: "/",
        display: "standalone",
        background_color: "#ffffff",
        theme_color: "#000000",
        icons: [
          {
            "src": "vite.svg",
            "sizes": "192x192",
            "type": "image/svg+xml",
            "purpose": "any maskable"
        },
        {
            "src": "vite.svg",
            "sizes": "512x512",
            "type": "image/svg+xml",
            "purpose": "any maskable"
        }
        ]
      }
    })
  ],
  server: {
    https: {
      cert: "localhost.pem",
      key: "localhost-key.pem",
    },
    host: '0.0.0.0',
    port: 3000,
  },
})
```

- продублировать модели в бекента в интерфейсы ts для удобства