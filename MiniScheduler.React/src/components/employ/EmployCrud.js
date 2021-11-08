import * as React from "react";
import { List, Datagrid, NumberField, TextField, ReferenceArrayField, AutocompleteArrayInput, SingleFieldList, ChipField, EmailField, DateField, Edit, SimpleForm, TextInput, Create, ReferenceArrayInput, SelectArrayInput } from 'react-admin';

export const EmployList = props => (
    <List {...props}>
        <Datagrid rowClick="edit">
            <NumberField source="id" />
            <TextField source="name" />
            <TextField source="surname" />
            <TextField source="telephone" />
            <EmailField source="email" />
            <DateField source="created" />
            <DateField source="updated" />
            <ReferenceArrayField source="skills" reference="skill" label="skills" >
                <SingleFieldList>
                    <ChipField source="name" />
                </SingleFieldList>
            </ReferenceArrayField>
        </Datagrid>
    </List>
);

export const EmployEdit = props => (
    <Edit {...props}>
        <SimpleForm>
            <NumberField disabled source="id" />
            <TextInput source="name" />
            <TextInput source="surname" />
            <TextInput source="telephone" />
            <TextInput source="email" />
            <ReferenceArrayInput source="skills" reference="skill">
                <AutocompleteArrayInput />
            </ReferenceArrayInput>
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
            <ReferenceArrayInput source="skills" reference="skill">
                <AutocompleteArrayInput />
            </ReferenceArrayInput>
        </SimpleForm>
    </Create>
);