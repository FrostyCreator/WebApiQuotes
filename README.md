# WebAPIQuotes

## Test

### Get all quotes
```
GET http://frostycreator.tk/api/quote/{random}/
```
|Name  | Type |Required|Description|
|------|------|--------|-----------|
|random| bool |   no   |get 1 random quote with|
### Return a single quote with a certain id
```
GET http://frostycreator.tk/api/quote/{id}/
```
|Name| Type |Required|Description|
|----|------|--------|-----------|
| id |uint32|  yes   | quote id  |

### Return all quotes with a certain theme
```
GET http://frostycreator.tk/api/quote/{theme}/{random}/
```
|Name  | Type |Required|Description|
|------|------|--------|-----------|
|theme |string|  yes   |theme name |
|random| bool |   no   |get 1 random quote with a certain theme|

### Add quote
```
POST http://frostycreator.tk/api/quote/
```
|Name | Type |Required|Description|
|-----|------|--------|-----------|
|Text |string|  yes   | quote text|
|Theme|string|  yes   |quote theme|

### Get themes
```
GET http://frostycreator.tk/api/theme
```

### Add theme
```
POST http://frostycreator.tk/api/theme
```
|Name | Type |Required|Description|
|-----|------|--------|-----------|
|Name |string|  yes   | Theme name|