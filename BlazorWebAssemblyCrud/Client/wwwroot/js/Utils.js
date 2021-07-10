var db = new Dexie("mydb");
var dbVersion = 1;

db.version(dbVersion).stores({
    crear: 'id++',
    borrar: 'id++'
});

async function getPendingRegisters() {
    return await {
        ObjectsToCreate: await db.crear.toArray(), //traer todos los valores de la tabla crear
        ObjectsToDelete: await db.borrar.toArray()
    };
}

//Función para borrar los registros por ID de la indexDB
async function deleteRegister(table, id) {
    await db[table].where({ "id": id }).delete();
}

//Funcion para obtener la cantidad de registros de las tablas de indexDB
async function getPendingRegistersCount() {
    const pendingCreates = await db.crear.count();
    const pendingDeletes = await db.borrar.count();
    return pendingCreates + pendingDeletes;
}

async function saveRegisterForCreate(url, body) {
    await db.crear.put({ url, body: JSON.parse(body)})
}

async function saveRegisterForDelete(url) {
    await db.borrar.put({ url })
}