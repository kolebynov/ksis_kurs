import ModelSchema from "./ModelSchema";
import DataTypes from "../common/DataTypes";
import ModelColumnSchema from "./ModelColumnSchema";

const schemas = [
    new ModelSchema({
        name: "Note",
        caption: "Записки",
        primaryColumnName: "id",
        displayColumnName: "name",
        resourceName: "notes",
        columns: [
            new ModelColumnSchema({
                name: "id",
                type: DataTypes.TEXT,
            }),
            new ModelColumnSchema({
                name: "name",
                type: DataTypes.TEXT,
                caption: "Имя"
            }),
            new ModelColumnSchema({
                name: "createdOn",
                type: DataTypes.DATETIME,
                caption: "Дата создания"
            }),
            new ModelColumnSchema({
                name: "modifiedOn",
                type: DataTypes.DATETIME,
                caption: "Дата изменения",
            }),
            new ModelColumnSchema({
                name: "description",
                type: DataTypes.TEXT,
                caption: "Описание",
            }),
            new ModelColumnSchema({
                name: "user",
                type: DataTypes.LOOKUP,
                referenceSchemaName: "User",
                caption: "Владелец",
                keyColumnName: "userId"
            })
        ]
    })
];

export default schemas;