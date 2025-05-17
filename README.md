# StudyTaskManager

**StudyTaskManager** — это веб-приложение для управления учебными задачами, реализованное в рамках группового проекта по дисциплине Web-технологии.  
Построено на базе ASP.NET Core с использованием MediatR, Entity Framework Core, FluentValidation и JWT-аутентификации. Проект следует модульной архитектуре и современным подходам к логированию, валидации и безопасности.

---

## ⚙️ Технологии и компоненты

- **ASP.NET Core Web API** — создание HTTP API  
- **Entity Framework Core (PostgreSQL)** — работа с базой данных  
- **MediatR** — реализация паттерна CQRS  
- **FluentValidation** — валидация входящих запросов  
- **Serilog** — логирование HTTP-запросов и внутренних событий  
- **JWT-аутентификация** — защита API и управление доступом  
- **Swagger (Swashbuckle)** — автоматическая генерация документации API  
- **CORS** — разрешение запросов с клиентского приложения  

---

## 🔒 Безопасность

- JWT-аутентификация через `Microsoft.AspNetCore.Authentication.JwtBearer`  
- Конфигурация токенов через кастомные `JwtOptionsSetup` и `JwtBearerOptionsSetup`  
- Авторизация по ролям с использованием атрибута `[Authorize(Roles = "...")]`  
- Хранение access-токена в `HttpOnly` Cookie для повышения безопасности  

---

## 📑 Swagger

- Поддержка авторизации через JWT  
- Кнопка **Authorize** в Swagger UI  
- Передача токена в заголовке `Authorization: Bearer {token}`  

---

## ✅ Основные возможности проекта

- **CQRS с MediatR:** все действия реализованы через команды и запросы  
- **Фильтрация:** через `Expression<Func<T, bool>>`, применяется к запросам LINQ  
- **Пагинация:** поддержка фильтров и постраничного вывода в одном объекте  
- **Валидация:** FluentValidation для декларативной проверки входящих данных  
- **Централизованная обработка ошибок:**  
  - Возвращает 400 Bad Request при ошибках  
  - Формирует `ProblemDetails` в едином формате  
  - Поддержка валидационных ошибок через `IValidationResult` с массивом `Error[]`  
- **Абстрактный контроллер `ApiController`:** интеграция с MediatR и централизованная обработка ошибок  

---

## 🧱 Доменные паттерны

### Value Object (DDD)

- Абстрактный класс `ValueObject` — основа для объектов-значений  
- Сравнение по атомарным свойствам, а не по идентификатору  
- Реализованы методы `GetAtomicValues()`, `Equals(...)`, `GetHashCode()`  
- Примеры использования: Email, Username, PhoneNumber, Password  

### Outbox Pattern (Гарантированная доставка событий)

- События сохраняются в таблицу `OutboxMessages` в рамках одной транзакции  
- Фоновая задача `ProcessOutboxMessagesJob` обрабатывает и публикует события через MediatR  
- Atomic persistence и fail-safe повторная доставка  
- Перехватчик `ConvertDomainEventsToOutboxMessagesInterceptor` автоматически конвертирует доменные события в Outbox-сообщения при вызове `SaveChangesAsync`  

---

## 📦 Persistence Layer: Generic Repository

- Абстрактный класс `TRepository<T>` реализует `IRepository<T>`  
- Поддержка гибкого получения данных с предикатами и пагинацией  
- Валидация через хуки:  
  - `VerificationBeforeAddingAsync`  
  - `VerificationBeforeUpdateAsync`  
  - `VerificationBeforeRemoveAsync`  
- Методы CRUD с поддержкой `AsNoTracking`  
- Использование `Result<T>` для обработки ошибок и успешных результатов  
- Инкапсуляция доступа к `AppDbContext` и `DbSet<T>`  

---

## 🗄 AppDbContext

- Основной класс для работы с базой данных (EF Core)  
- DbSet-свойства для всех доменных сущностей (Пользователи, Роли, Чаты, Задачи и др.)  
- Автоматическое создание базы данных при первом запуске (`Database.EnsureCreated()`)  
- Конфигурации сущностей в папке `Configurations`  
- Настройка подключения к PostgreSQL  

---

## 🏗 UnitOfWork (Паттерн "Единица работы")

- Инкапсулирует вызов `_dbContext.SaveChangesAsync()`  
- Обеспечивает атомарность сохранения изменений в базе данных  

```csharp
internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _dbContext;

    public UnitOfWork(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
