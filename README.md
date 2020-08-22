# WebAPIQuotes

## Test

### Get all quotes
```
GET http://frostycreator.tk/api/quote/{random}/
```
|Name  | Type |Required|Description|
|------|------|--------|-----------|
|random| bool |   no   |Get 1 random quote|
### Return a single quote with a certain id
```
GET http://frostycreator.tk/api/quote/{id}/
```
|Name| Type |Required|Description|
|----|------|--------|-----------|
| id |uint32|  yes   | Quote id  |

### Return all quotes with a certain theme
```
GET http://frostycreator.tk/api/quote/{theme}/{random}/
```
|Name  | Type |Required|Description|
|------|------|--------|-----------|
|theme |string|  yes   |Theme name |
|random| bool |   no   |Get 1 random quote with a certain theme|

### Add quote
```
POST http://frostycreator.tk/api/quote/
```
|Name | Type |Required|Description|
|-----|------|--------|-----------|
|text |string|  yes   | Quote text|
|theme|string|  yes   |Quote theme|

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
|name |string|  yes   | Theme name|
