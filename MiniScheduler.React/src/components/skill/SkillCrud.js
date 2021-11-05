import * as React from "react";
import { List, Datagrid, TextField, DateField, Edit, SimpleForm, TextInput, DateInput, Create } from 'react-admin';

export const SkillList = props => (
    <List {...props}>
        <Datagrid rowClick="edit">
            <TextField source="id" />
            <TextField source="name" />
            <TextField source="description" />
            <DateField source="created" />
            <TextField source="updated" />
            <TextField source="employees" />
        </Datagrid>
    </List>
);

export const SkillEdit = props => (
    <Edit {...props}>
        <SimpleForm>
            <TextInput disabled soure="id" />
            <TextInput source="name" />
            <TextInput source="description" />
            <DateInput source="created" />
            <TextInput source="employees" />
        </SimpleForm>
    </Edit>
);

export const SkillCreate = props => (
    <Create {...props}>
        <SimpleForm>
            <TextInput source="name" />
            <TextInput source="description" />
            <TextInput source="employees" />
        </SimpleForm>
    </Create>
);