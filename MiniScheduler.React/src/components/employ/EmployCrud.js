import * as React from "react";
import { List, Datagrid, TextField, EmailField, DateField, Edit, SimpleForm, TextInput, Create } from 'react-admin';

export const EmployList = props => (
    <List {...props}>
        <Datagrid rowClick="edit">
            <TextField source="id" />
            <TextField source="name" />
            <TextField source="surname" />
            <TextField source="telephone" />
            <EmailField source="email" />
            <DateField source="created" />
            <TextField source="updated" />
            <TextField source="skills" />
        </Datagrid>
    </List>
);

export const EmployEdit = props => (
    <Edit {...props}>
        <SimpleForm>
            <TextInput disabled source="id" />
            <TextInput source="name" />
            <TextInput source="surname" />
            <TextInput source="telephone" />
            <TextInput source="email" />
            <TextInput source="skills" />
        </SimpleForm>
    </Edit>
);

export const EmployCreate = props => (
    <Create {...props}>
        <SimpleForm>
            <TextInput source="name" />
            <TextInput source="surname" />
            <TextInput source="telephone" />
            <TextInput source="email" />
            <TextInput source="skills" />
        </SimpleForm>
    </Create>
);