# Exercise 2

- A **company** needs a delivery management system for its customers.
- Each **customer** can place many orders, and each order will be delivered to a specific address.
- **Products** can belong to many orders, and each order can have multiple products.
- Each **order** can be delivered by many different shipping companies.

---

This project code follow three layers architectures: but i combine bus and Gui layer together decrease complexity of project

    - DAL: has entities, dbcontext, repositories, unit of work,  configuration.
    - Bus: use repositories and menu of the class (UI)
    - gui: UI of console app

**The code split query, concurrency, split query, eager loading , ...** in customer repository() and customer business()

---
12h đêm deadline nhé,

Generic repository, CRUD trên tất cả các entity,

    - [x] kế thừa theo từng entity và
    - [x] Load related entity,
    - [x] split query,
    - [x] concurrency,
    - [x] eager loading,
    - [x] explicit loading,
    - [x] lazy loading,
    - [x] transaction
    - [x] generic repository
    - [x] fluent api, config relationship
    - [x] Add data by random method
    - [x] Load related entity each entity

tất cả những kĩ thuật hôm qua được học, nhé

nộp lên gitlab từ máy cá nhân tên repository trên gitlab sẽ là Account-EFCore

Generic reposiotry với thêm hàm custom load related data theo từng entity nữa

    - [x] config using FluentAPI 
    - [x] use real data base(SQL, PostgresQL, - MySQL…) 
    - [x] CRUD the table 
    - [x] compare performance between tracking  vs - no tracking using *jmeter* 
    - [x] insert parent table & children table  in - 1 command 
    - [x] update table but do not use context. Entity.update method. 
    - [x] create seed method data 
    - [x] config seed data in context class. 
    - [ ] checking the state of the entity when “something happen” update/delete/- insert 
    - [x] learn how to config 1-1, 1-n, n-n 
    - Query Relation data using 
      -  [x]eager  loading
      -  [x]lazy loading
      -  [x]explitcity loading
    - Comments 

```c#

dotnet add package Microsoft.EntityFrameworkCore.SqlServer

dotnet add package Microsoft.EntityFrameworkCore.Tools

dotnet add package Microsoft.EntityFrameworkCore

dotnet add package Microsoft.EntityFrameworkCore.Design
// package for lazy loading
Microsoft.EntityFrameworkCore.Proxies
```

## Run Project

- Run command `dotnet restore'
- Update connect string in `appsettings.json`
- Run project
