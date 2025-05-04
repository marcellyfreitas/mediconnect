import { Stack } from 'expo-router';
import { colors } from '@/utils/constants';

export default function RootLayout() {
	return (
		<Stack initialRouteName="index" >
			<Stack.Screen name="index"
				options={{
					headerShown: true,
					headerTitle: '',
					headerStyle: {
						backgroundColor: colors.green,
					},
					headerTintColor: colors.blue,
				}}
			/>

			<Stack.Screen name="agendamentos"
				options={{ headerShown: false }}
			/>

			<Stack.Screen name="exames"
				options={{ headerShown: false }}
			/>

			<Stack.Screen name="unidades"
				options={{ headerShown: false }}
			/>

			<Stack.Screen name="convenios"
				options={{ headerShown: false }}
			/>
		</Stack>
	);
}
