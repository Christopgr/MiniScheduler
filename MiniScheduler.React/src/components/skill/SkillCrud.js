import * as React from "react";
import { List, Datagrid, TextField, DateField, Edit, SimpleForm, TextInput, Create, NumberField } from 'react-admin';

export const SkillList = props => (
    <List {...props}>
        <Datagrid rowClick="edit">
            <NumberField source="id" />
            <TextField source="name" />
            <TextField source="description" />
            <DateField source="created" />
            <DateField source="updated" />
            <TextField source="employees" />
        </Datagrid>
    </List>
);

export const SkillEdit = props => (
    <Edit {...props}>
        <SimpleForm>
            <NumberField source="id" />
            <TextInput source="name" />
            <TextInput source="description" />
            <DateField disable="true" source="created" />
        </SimpleForm>
    </Edit>
);

export const SkillCreate = props => (
    <Create {...props}>
        <SimpleForm>
            <TextInput source="name" />
            <TextInput source="description" />
        </SimpleForm>
    </Create>
);