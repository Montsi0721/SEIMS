# SEIMS - Testing documentation

Take a screenshot for each row marked **[screenshot]** and paste it under the test.
Run `SEIMS.exe --demo` (or add `--demo` under *Project > Properties > Debug > Command line arguments*) for the console traces.

## A. Debugging console traces  [screenshot]
| # | Action | Expected result |
|---|--------|-----------------|
| A1 | Run with `--demo` | Sections 1-7 print: override vs `new` hiding, object counters, deep copy, indexer/iterator, delegate+event alert, safe conversions, LINQ output |
| A2 | In Visual Studio set a **breakpoint** on `ItemWarehouse.NotifyIfCritical` and run the app; edit an item to quantity 2 | Breakpoint is hit; `item.Quantity` is 2 in the Locals window  [screenshot] |
| A3 | Breakpoint on `SafeParser.ToInt32Strict`; save the item form with `abc` as quantity | Breakpoint hit, `FormatException` caught, friendly message shown  [screenshot] |
| A4 | Breakpoint inside `InventoryItem` destructor (`~InventoryItem`), then Settings > *Run garbage collection* | Output window shows "[InventoryItem] finalised ..."; "Objects alive" drops  [screenshot] |

## B. Invalid input handling  [screenshot each]
| # | Input | Expected |
|---|-------|----------|
| B1 | Add item, quantity `abc` (type a letter) | Letter is blocked by the key filter |
| B2 | Paste `12abc` into Quantity and Save | "Quantity must be a whole number (you typed '12abc')." |
| B3 | Quantity `99999999999` | "Quantity is too large or too small." |
| B4 | Unit price `1.2.3` | "Unit price must be a number such as 12.50" |
| B5 | SKU `ITM-001` (already exists) | "An item with SKU 'ITM-001' already exists." |
| B6 | SKU `!!` | "SKU must be 3-30 letters, digits or dashes" |
| B7 | Name `<script>alert(1)</script>` | Angle brackets removed - stored as `scriptalert(1)/script` |
| B8 | Perishable with max temp lower than min temp | "Maximum temperature cannot be lower than the minimum." |
| B9 | File > Import CSV > `Docs/sample_import.csv` | 2 imported, 4 skipped; errors list bad quantity, unknown category, duplicate SKU, missing column |
| B10 | Stop SQL Server / change the connection string and start the app | Friendly "could not reach SQL Server" message (SqlException handled) |

## C. Security
| # | Action | Expected |
|---|--------|----------|
| C1 | Sign in as `viewer` | Add / Edit / Delete / Print / Export are disabled; icons grey |
| C2 | Sign in as `manager`, press the red trash icon | "Access denied: delete items (Administrators only)" |
| C3 | Sign in as `admin`, delete an item | Confirmation, item removed, **DELETE** row appears in Audit Logs |
| C4 | Three wrong passwords | Warning and the application closes |
| C5 | `manager` > Print preview of a report | Price / value columns print as `***`; `admin` sees the numbers |
| C6 | Any print | Footer line "CONFIDENTIAL - printed by ..." and a PRINT audit row |

## D. Features
| # | Action | Expected |
|---|--------|----------|
| D1 | Dashboard | Cards 124 / low stock / expiring / audit count; grid + details as in the design |
| D2 | Edit an item to quantity `2`, Save | Critical stock alert box (event fired), orange message in the status bar, line in `seims.log` |
| D3 | Search `milk`, filter *Very Low*, change page | Grid, pager and "Showing x - y of n items" update |
| D4 | Categories page | TreeView lists categories and items; selecting shows `GetItemDetails()` |
| D5 | Reports page, all 9 reports | Query-syntax and method-syntax versions give identical results |
| D6 | Reports > Export XML (twice) | Tracking number goes `EXP-0001`, then `EXP-0002`; XML opens in a browser |
| D7 | Package Manager Console `Add-Migration InitialCreate`, `Update-Database` | Migration files created; tables `InventoryItems`, `Suppliers`, `Categories`... exist  [screenshot of SSMS / SQL Server Object Explorer] |
| D8 | Manual compile (`ManualCompile\build.bat`) | DLL + EXE built and run  [screenshot] |
