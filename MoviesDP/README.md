# MoviesDP ![Polska](https://img.shields.io/badge/Language-Polish-red?style=flat&logo=flag-icon&logoColor=white)

MoviesDP to aplikacja ASP.NET Core do zarządzania filmami i ich obsadą. Aplikacja umożliwia dodawanie, edytowanie i usuwanie filmów oraz osób związanych z filmami. Dostęp do formularzy mają tylko zalogowani użytkownicy.

## Funkcje


- **Zarządzanie filmami**: Dodawanie, edytowanie i usuwanie filmów.
- **Zarządzanie obsadą**: Dodawanie, edytowanie i usuwanie osób związanych z filmami.
- **Autoryzacja użytkowników**: Dostęp do formularzy mają tylko zalogowani użytkownicy.
- **Walidacja danych**: Walidacja danych wejściowych w formularzach.

## Jak uruchomić aplikację 
0. Pobierz plik bazy danych z [databasestar](https://github.com/bbrumm/databasestar/blob/main/sample_databases/sample_db_movies/sqlite/movies.db)

1. 
   W ```appsetings.json``` zmień wartość ```MoviesDatabase```
   na folder z plikiem po ```data source=```
   
2. Przywróć zależności
    ```sh
    dotnet restore
    ```
3. Zbuduj program
   ```sh
   dotnet build
   ```
4. Uruchom program
   ```sh
   dotnet watch
   ```
   albo
   ```sh
   cd bin\Debug\net8.0\
   ```
   ```sh
   dotnet MoviesDP.dll
   ```
## Technologie

Aplikacja została zbudowana przy użyciu następujących technologii:
- ASP.NET Core
- Razor Pages
- Bootstrap
- jQuery

## Użycie

### Autoryzacja użytkowników

Aplikacja korzysta z ASP.NET Core Identity do zarządzania użytkownikami i rolami. Dostęp do formularzy mają tylko zalogowani użytkownicy.

### Dodawanie osoby do filmu

1. Przejdź do strony szczegółów filmu.
2. Kliknij przycisk "Add Person".
3. Wypełnij formularz i kliknij "Submit".

### Walidacja danych

Formularze w aplikacji są walidowane zarówno po stronie klienta, jak i serwera. W przypadku błędów walidacji, użytkownik otrzyma odpowiednie komunikaty o błędach.
