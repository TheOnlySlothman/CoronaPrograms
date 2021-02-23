use testDB

execute ItemToInventory @playerId = 2, @itemId = 1
execute DropItem @playerId = 2, @inventoryId = 2
execute GetPlayers
execute UpdateItem @playerId = 2, @itemId = 2, @inventoryId = 1