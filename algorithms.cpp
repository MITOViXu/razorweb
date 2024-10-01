#include<bits/stdc++.h>
using namespace std;


void printArray(int A[], int size){
    int i;
    for (i = 0; i < size; i++)
        cout<<A[i]<<" ";
    printf("\n");
}

void BubbleSort(int a[], int n){
//	for (int i = 0; i < n - 1; i++) {
//        for (int j = 0; j < n - i - 1; j++) {  // Fix the loop to not go out of bounds
//            if (a[j] < a[j+1]) {  // Sort in descending order
//                // Swap elements
//                int temp = a[j];
//                a[j] = a[j+1];
//                a[j+1] = temp;
//                cout<<endl<<"J = "<<j+1;
//            }
//        }
//    }
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {  // Fix the loop to not go out of bounds
            if (a[i] > a[j]) {  // Sort in descending order
                // Swap elements
                int temp = a[i];
                a[i] = a[j];
                a[j] = temp;
                cout<<endl<<"J = "<<j+1;
            }
        }
    }
}

void merge(int arr[], int l, int m, int r){
	int i=0, j=0, k=l;
	int n1 = m - l + 1;
	int n2 =  r - m;
	int L[n1], R[n2];
	for(int i=0; i<n1; i++){
		L[i] = arr[l+i];
	}
	for(int i=0; i<n1; i++){
		R[i] = arr[m+1+i];
	}
	while(i<n1 && j <n2){
		if(L[i]>R[j]){
			arr[k]=L[i];
			k++;
			i++;	
		}
		else{
			arr[k]=R[j];
			k++;
			j++;
		}
	}
	while(i<n1){
		arr[k]=L[i];
		k++;
		i++;
	}
	while(j<n2){
		arr[k]=R[j];
		k++;
		j++;
	}
}

void mergeSort(int arr[], int l, int r){
	int m = l + (r-l) / 2;
	if(l<r){
		mergeSort(arr, l, m);
		mergeSort(arr, m+1, r);
	}
	merge(arr, l, m, r);
}

void quickSort()

int main(){
	
	// Bubble sort example
//	int a[5] = {1,2,3,4,5};
//	BubbleSort(a,sizeof(a) / sizeof(a[0]));
//	cout<<endl;
//	cout<<"Size of A: " <<sizeof(a) / sizeof(a[0]);
//	cout<<endl;
//	cout<<"a[";
//	for(int i=0; i<15-1; i++){
//		cout<<a[i]<<",";
//	}
//	cout<<a[(sizeof(a) / sizeof(a[0]))-1];
//	cout<<"]";
//	return 0;

	// Merge sort example	
//	int arr[] = {1,2,3,4,5,6};
//	int arr_size = sizeof(arr) / sizeof(arr[0]);
//	cout<<endl<<"Array size is: "<<arr_size<<endl<<endl;
// 	printf("Given array is \n");
//    printArray(arr, arr_size);
//
//    mergeSort(arr, 0, arr_size - 1);
//
//    printf("\nSorted array is \n");
//    printArray(arr, arr_size);
//    return 0;
    
    
    
}