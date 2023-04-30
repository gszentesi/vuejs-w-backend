<template>
    <div class="flex flex-column gap-3">
        <DataTable
            v-model:filters="filters"
            :value="customers"
            dataKey="id"
            paginator
            :rows="5"
            :rowsPerPageOptions="[5, 10, 20, 50]"
            tableStyle="width: 100%"
            paginatorTemplate="RowsPerPageDropdown FirstPageLink PrevPageLink CurrentPageReport NextPageLink LastPageLink"
            currentPageReportTemplate="{first} to {last} of {totalRecords}"
            filterDisplay="menu"
        >
            <template #paginatorstart>
                <Button type="button" icon="pi pi-refresh" text />
            </template>
            <template #paginatorend>
                <Button type="button" icon="pi pi-download" text />
            </template>
            <Column field="name" header="Name" sortable style="width: 25%">
                <template #body="{ data }">
                    {{ data.name }}
                </template>
                <template #filter="{ filterModel }">
                    <InputText
                        v-model="filterModel.value"
                        type="text"
                        class="p-column-filter"
                        placeholder="Search by name"
                    />
                </template>
            </Column>
            <Column field="country.name" header="Country" sortable style="width: 25%"></Column>
            <Column field="company" header="Company" sortable style="width: 25%"></Column>
            <Column
                field="representative.name"
                header="Representative"
                sortable
                style="width: 25%"
            ></Column>
        </DataTable>
    </div>
</template>

<style scoped>
.p-datatable {
    display: flex !important;
    flex-direction: column !important;
    flex-grow: 1 !important;
}
</style>

<script setup>
import { ref, onMounted } from 'vue'
import { useCustomerStore } from '@/stores/customer'
import { FilterMatchMode, FilterOperator } from 'primevue/api'

const filters = ref({
    name: {
        operator: FilterOperator.AND,
        constraints: [{ value: null, matchMode: FilterMatchMode.STARTS_WITH }]
    }
})

const customerStore = useCustomerStore()

onMounted(() => {
    customerStore.get()
    customers.value = customerStore.data
})

const customers = ref()
</script>
