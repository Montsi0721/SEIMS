# SEIMS - Secure Enterprise Inventory & Audit Management System
Programming using .Net 1 (C7-PN1-11) - Windows Forms, C#, LINQ, Entity Framework Core, SQL Server.
The user interface follows the dark dashboard design (sidebar, summary cards, recent items grid, item details panel).

## Requirements
* Windows 10 / 11
* Visual Studio 2022 with the **.NET desktop development** workload (.NET 8 SDK)
* SQL Server LocalDB (installed with Visual Studio) - or edit `SEIMS/appsettings.json` to point at any SQL Server

## Run it
1. Open `SEIMS.sln` in Visual Studio. NuGet restores `Microsoft.EntityFrameworkCore.SqlServer` and `.Tools`.
2. **Create the migration** (Question 8) - *Tools > NuGet Package Manager > Package Manager Console*, default project **SEIMS**:
   ```
   Add-Migration InitialCreate
   Update-Database
   ```
   (If you skip this, the app creates the database from the model on first start. Do the migration step for the "migration files" deliverable.)
3. Press **F5**. First start creates `SeimsDb` and seeds 124 items, 4 categories, 4 suppliers and 3 accounts.

| Username | Password | Role | Can do |
|----------|----------|------|--------|
| `admin` | `Admin@123` | Admin | everything, including **delete** |
| `manager` | `Manager@123` | Manager | add, edit, import, export, print |
| `viewer` | `Viewer@123` | Viewer | read only |

Console trace for screenshots: run with the argument `--demo`.
Log file: `%LocalAppData%\SEIMS\Logs\seims.log`.


## Editing the UI with drag and drop (Visual Studio Forms Designer)
Every screen has a real designer file, so you can open it by double-clicking the `.cs` file (or right-click > *View Designer*):

| Screen | Open this | What you can drag / edit |
|--------|-----------|--------------------------|
| Main window (menu, toolbar, status bar, sidebar, header) | `UI/MainForm.cs` | MenuStrip, ToolStrip, StatusStrip, sidebar `NavButton`s |
| Sign-in | `UI/LoginForm.cs` | labels, text boxes, buttons |
| Add / edit item dialog | `UI/ItemEditForm.cs` | TableLayoutPanel rows, DateTimePicker, NumericUpDown |
| Dashboard | `UI/Views/DashboardView.cs` | 4 `StatCard`s, grid panel, details panel |
| Recent items card | `UI/Controls/ItemsGridPanel.cs` | search box, filter menu, DataGridView columns, pager bar |
| Item details card | `UI/Controls/ItemDetailsPanel.cs` | tabs, pills, buttons, description |
| Categories / Audit Logs / Reports / Settings / View Items | `UI/Views/*.cs` | TreeView, DataGridView, DateTimePicker, buttons |

**First time:** build the solution once (Ctrl+Shift+B) so the custom controls appear in the Toolbox under *SEIMS.* (`ThemedButton`, `CardPanel`, `DarkGrid`, `StatCard`, `NavButton`, `Pill`, `IconTile`, `KeyValueList`).
* `ThemedButton.Kind` = Primary / Secondary / Ghost / Danger (blue, dark, outlined, red).
* `CardPanel` = a panel with the 1px card border. `DarkGrid` = a DataGridView that already has the dark style.
* Pages are created at run time by `MainForm`, so edit each page in its own file; the main window just hosts them.
* Event handlers (`btnSave_Click`, `navDashboard_Click` ...) live in the matching `.cs` file; double-click a control to add new ones.

## Where each question is answered
| Q | Marks | File(s) |
|---|-------|---------|
| 1 Classes & OOP | 10 | `Models/InventoryItem.cs` + `InventoryItem.Behavior.cs` (**partial class in 2 files**), `PerishableItem.cs` (override `GetItemDetails`, `new Describe`), constructor/destructor counters |
| 2 Interfaces & comparisons | 8 | `IStorable.cs`, `ICloneable` + `DeepCopy()`, `Equals` / `GetHashCode` on SKU |
| 3 Collections & iterators | 7 | `Collections/ItemWarehouse.cs` - string indexer `warehouse["ITM-002"]`, `ItemsInCategory` with `yield return` |
| 4 Delegates & events | 12 | `Events/LogHandler.cs`, `ItemWarehouse.OnStockThresholdCritical` (fires below 5), `Events/NotificationService.cs` |
| 5 Error handling | 8 | `Services/SafeParser.cs` (`int.TryParse`, `Convert.ToInt32`, try/catch/finally, local vs static scope), `CsvImporter.cs` (FormatException, SqlException), `MainForm.RunGuarded` |
| 6 File I/O + manual compile | 8 | `Services/FileLogger.cs` (FileStream/StreamWriter/StreamReader), `ManualCompile/`, `Notepad_Proof_csc_commands.txt` |
| 7 LINQ | 10 | `Services/ReportEngine.cs` - every report in query **and** method syntax, orderby desc, Sum/Average, Join + Group |
| 8 Entity Framework | 12 | `Data/SeimsDbContext.cs` (Supplier 1-to-many InventoryItems, Category 1-to-many), migrations via PMC, `Services/XmlExporter.cs` |
| 9 Windows Forms | 15 | `UI/MainForm*` (MenuStrip, ToolStrip, StatusStrip), `DataGridView` (grid panel), `TreeView` (Categories), `DateTimePicker` (expiry filter, edit form), data loaded straight from EF |
| 10 Security | 10 | `Services/SecurityService.cs` (PBKDF2 hashed passwords, roles, `Demand`), `SecurePrinter.cs`, `InputSanitizer.cs` + key filters in `ItemEditForm` |

## Deliverables checklist
* Source code - this solution
* Database scripts - run `Add-Migration InitialCreate` (step 2) and zip the generated `Migrations` folder
* Notepad proof - `Notepad_Proof_csc_commands.txt` (+ screenshot of `ManualCompile\build.bat`)
* Testing documentation - `Docs/Testing_Documentation.md` lists every test and the screenshot to take

## Notes
* The forms are laid out in standard `*.Designer.cs` partial classes (`InitializeComponent`) that the Forms Designer can open and edit; custom-drawn controls give the dashboard look.
  Test at 100 % and 125 % Windows scaling.
* Icons come from the *Segoe MDL2 Assets* font that ships with Windows 10/11.
