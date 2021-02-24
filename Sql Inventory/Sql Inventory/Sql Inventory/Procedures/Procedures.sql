use testDB

execute ItemToInventory @playerId = 2, @itemId = 1
execute DropInventoryItem @playerId = 2, @inventoryId = 2
execute GetPlayers
execute UpdateItem @playerId = 2, @itemId = 2, @inventoryId = 1
execute ShowItems
execute DeleteItem @itemID = 1